using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SLMS.Application.Contracts.Identity;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;
using SLMS.ApplicationCore.Domain.InstituteManagement;
using SLMS.Shared.Enums;

namespace SLMS.Application.Features.InstituteManagement.TermCourse.Commands
{
    public class UpdateTermCourseCommandHandler : IRequestHandler<UpdateTermCourseCommand, TermCourseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUser;
        public UpdateTermCourseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUser)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task<TermCourseCommandResponse> Handle(UpdateTermCourseCommand request, CancellationToken cancellationToken)
        {

            var userId = _currentUser.Id!.Value;

            var loginedUserMembership = await _unitOfWork.InstituteMembershipRepository.GetUserMembersShipByUserIdAsync(
               userId, request.InstituteId, cancellationToken) ?? throw new NotFoundException();

            if (!loginedUserMembership.MembershipRoles.Any(r => r.MemberType == MemberType.Admin) &&
                !loginedUserMembership.MembershipRoles.Any(r => r.MemberType == MemberType.Founder))
                throw new UnauthorizedException("شما اجازه پردازش درخواست را ندارید.");

            var termCourseEntity = await _unitOfWork.TermCourseRepository.GetByIdWithSessionDaysAsync(request.Id, 
                cancellationToken);


            if (termCourseEntity == null)
                throw new NotFoundException(nameof(TermCourse), request.Id);

            var teacherMembership = await _unitOfWork.InstituteMembershipRepository.GetUserMembersShipByIdAsync(
               request.TeacherId,request.InstituteId, cancellationToken) ?? throw new NotFoundException();

            if (!teacherMembership.MembershipRoles.Any(x=>x.MemberType==MemberType.Teacher))
                throw new ForbiddenException("کاربر انتخاب شده معلم نمی باشد.");

            var teacherConflict = await _unitOfWork.TermCourseRepository.HasTeacherConflictAsync(
                request.TeacherId,
                request.StartTime, request.EndTime,
                request.StartDate, request.EndDate,
                request.WeekDays,
                cancellationToken, request.Id);

            if (teacherConflict)
                throw new ConflictException("تداخل کلاسی برای این معلم وجود دارد");


            var roomConflict = await _unitOfWork.TermCourseRepository.HasRoomConflictAsync(
                   request.RoomId,
                   request.StartTime, request.EndTime,
                   request.StartDate, request.EndDate,
                   request.WeekDays,
                   cancellationToken, request.Id);


            if (roomConflict)
                throw new ConflictException("تداخل کلاسی برای این اتاق وجود دارد");

            _mapper.Map(request, termCourseEntity);

            var oldDays = termCourseEntity.TermCourseSessionDays.ToList();
            _unitOfWork.TermCourseSessionDayRepository.HardDeleteRange(oldDays);

            var newSessionDays=request.WeekDays.Select(day => new TermCourseSessionDay
            {
                TermCourseId = termCourseEntity.Id,
                WeekDay = day
            }).ToList();

            await _unitOfWork.TermCourseSessionDayRepository.AddRangeAsync(newSessionDays, cancellationToken);
         
            await _unitOfWork.CommitAsync();
            return _mapper.Map<TermCourseCommandResponse>(termCourseEntity);

        }
    }
}
