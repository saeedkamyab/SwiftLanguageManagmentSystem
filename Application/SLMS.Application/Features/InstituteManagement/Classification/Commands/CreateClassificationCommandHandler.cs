using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Identity;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;
using SLMS.ApplicationCore.Domain.InstituteManagement;
using SLMS.Shared.Enums;

namespace SLMS.Application.Features.InstituteManagement.Classification.Commands
{
    public class CreateClassificationCommandHandler : IRequestHandler<CreateClassificationCommand, ClassificationCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateClassificationCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ICurrentUserService currentUser)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public async Task<ClassificationCommandResponse> Handle(CreateClassificationCommand request,
            CancellationToken cancellationToken)
        {

            var pupilMembership = await _unitOfWork.InstituteMembershipRepository.GetUserMembersShipByIdAsync(
               request.PupilMembershipId, request.InstituteId, cancellationToken) ?? throw new NotFoundException();

            if (!pupilMembership.MembershipRoles.Any(x => x.MemberType == MemberType.Pupil))
                throw new ForbiddenException("کاربر انتخاب شده شاگرد نمی باشد.");


            var conflict = await _unitOfWork.ClassificationRepository
       .GetScheduleConflictAsync(
           request.PupilMembershipId,
           request.TermCourseId,
           request.InstituteId,
           cancellationToken);

            if (conflict is not null)
            {
                throw new ConflictException(
                    $"این شاگرد قبلاً در کلاس '{conflict.TermCourse!.Title}' ثبت شده است.");
            }


            var classification = _mapper.Map<ApplicationCore.Domain.InstituteManagement.Classification>(request);
            var result = await _unitOfWork.ClassificationRepository.AddAsync(classification, cancellationToken);
          
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ClassificationCommandResponse>(result);

        }
    }
}
