using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Identity;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;
using SLMS.Shared.Enums;

namespace SLMS.Application.Features.InstituteManagement.MembershipRequest.Commands
{
    public class RejectMembershipRequestCommandHandler : IRequestHandler<RejectMembershipRequestCommand, MembershipRequestCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUser;

        public RejectMembershipRequestCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ICurrentUserService currentUser)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<MembershipRequestCommandResponse> Handle(RejectMembershipRequestCommand request,
            CancellationToken cancellationToken)
        {
            var userId = _currentUser.Id ?? throw new UnauthorizedException();

            var membershipRequest = await _unitOfWork.MembershipRequestRepository.GetByIdAsync(request.Id, cancellationToken);

            if (membershipRequest == null)
                throw new NotFoundException("درخواست عضویت یافت نشد.");

            if (membershipRequest.Status != MembershipRequestStatus.Pending)
                throw new ConflictException("درخواست قبلا بررسی شده است.");

            var loginedUserMembership = await _unitOfWork.InstituteMembershipRepository.GetUserMembersShipAsync(
                userId, membershipRequest.InstituteId, cancellationToken) ?? throw new NotFoundException();

            if (loginedUserMembership.MemberType != MemberType.Admin &&
                loginedUserMembership.MemberType != MemberType.Founder)
                throw new UnauthorizedException("شما اجازه پردازش درخواست را ندارید.");

            var requestedUserMembership = await _unitOfWork.InstituteMembershipRepository.GetUserMembersShipAsync(
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
