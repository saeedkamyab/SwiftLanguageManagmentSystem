using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Identity;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;
using SLMS.ApplicationCore.Domain.InstituteManagement;
using SLMS.Shared.Enums;

namespace SLMS.Application.Features.InstituteManagement.TermCourse.Commands
{
    public class CreateTermCourseCommandHandler : IRequestHandler<CreateTermCourseCommand, TermCourseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUser;

        public CreateTermCourseCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ICurrentUserService currentUser)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<TermCourseCommandResponse> Handle(CreateTermCourseCommand request,
            CancellationToken cancellationToken)
        {
            var userId = _currentUser.Id!.Value;

            var loginedUserMembership = await _unitOfWork.InstituteMembershipRepository.GetUserMembersShipByUserIdAsync(
               userId, request.InstituteId, cancellationToken) ?? throw new NotFoundException();

            if (!loginedUserMembership.MembershipRoles.Any(r => r.MemberType == MemberType.Admin) &&
                !loginedUserMembership.MembershipRoles.Any(r => r.MemberType == MemberType.Founder))
                throw new UnauthorizedException("شما اجازه پردازش درخواست را ندارید.");



            var teacherMembership = await _unitOfWork.InstituteMembershipRepository.GetUserMembersShipByIdAsync(
               request.TeacherId, request.InstituteId, cancellationToken) ?? throw new NotFoundException();

            if (!teacherMembership.MembershipRoles.Any(x => x.MemberType == MemberType.Teacher))
                throw new ForbiddenException("کاربر انتخاب شده معلم نمی باشد.");


            var teacherConflict = await _unitOfWork.TermCourseRepository.HasTeacherConflictAsync(
                request.TeacherId,
                request.StartTime, request.EndTime,
                request.StartDate, request.EndDate,
                request.WeekDays,
                cancellationToken);

            if (teacherConflict)
                throw new ConflictException("تداخل کلاسی برای این معلم وجود دارد");


            var roomConflict = await _unitOfWork.TermCourseRepository.HasRoomConflictAsync(
                   request.RoomId,
                   request.StartTime, request.EndTime,
                   request.StartDate, request.EndDate,
                   request.WeekDays,
                   cancellationToken);


            if (roomConflict)
                throw new ConflictException("تداخل کلاسی برای این اتاق وجود دارد");



            var termCourse = _mapper.Map<ApplicationCore.Domain.InstituteManagement.TermCourse>(request);
            var result = await _unitOfWork.TermCourseRepository.AddAsync(termCourse, cancellationToken);
            result.IsActive = true;

            foreach (var item in request.WeekDays)
            {
                await _unitOfWork.TermCourseSessionDayRepository.AddAsync(new TermCourseSessionDay
                {
                    TermCourseId = result.Id,
                    WeekDay = item
                }, cancellationToken);
            }


            await _unitOfWork.CommitAsync();
            return _mapper.Map<TermCourseCommandResponse>(result);

        }
    }
}
