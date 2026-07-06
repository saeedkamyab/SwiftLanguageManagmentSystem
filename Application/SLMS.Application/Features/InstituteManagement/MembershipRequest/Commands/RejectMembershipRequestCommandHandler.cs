using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;
using SLMS.Shared.Enums;

namespace SLMS.Application.Features.InstituteManagement.MembershipRequest.Commands
{
    public class RejectMembershipRequestCommandHandler : IRequestHandler<RejectMembershipRequestCommand, MembershipRequestCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RejectMembershipRequestCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<MembershipRequestCommandResponse> Handle(RejectMembershipRequestCommand request,
            CancellationToken cancellationToken)
        {

            var membershipRequest = await _unitOfWork.MembershipRequestRepository.GetByIdAsync(request.Id, cancellationToken);

            if (membershipRequest == null)
                throw new NotFoundException("درخواست عضویت یافت نشد.");

            if (membershipRequest.Status != MembershipRequestStatus.Pending)
                throw new ConflictException("درخواست قبلا بررسی شده است.");

            var requestedUserMembership = await _unitOfWork.InstituteMembershipRepository.GetUserMembersShipByUserIdAsync(
                membershipRequest.UserId, membershipRequest.InstituteId, cancellationToken);

            if (requestedUserMembership != null)
                throw new ConflictException("این کاربر قبلا عضو آموزشگاه می باشد.");

            membershipRequest.Status = MembershipRequestStatus.Rejected;
            _unitOfWork.MembershipRequestRepository.Update(membershipRequest);

            await _unitOfWork.CommitAsync();
            return _mapper.Map<MembershipRequestCommandResponse>(membershipRequest);
        }

    }

}
