using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Identity;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;
using SLMS.Shared.Enums;

namespace SLMS.Application.Features.InstituteManagement.MembershipRequest.Commands
{
    public class ApproveMembershipRequestCommandHandler : IRequestHandler<ApproveMembershipRequestCommand, MembershipRequestCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUser;

        public ApproveMembershipRequestCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ICurrentUserService currentUser)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<MembershipRequestCommandResponse> Handle(ApproveMembershipRequestCommand request,
            CancellationToken cancellationToken)
        {
            var userId = _currentUser.Id ?? throw new UnauthorizedException();

            var membershipRequest = await _unitOfWork.MembershipRequestRepository.GetByIdAsync(request.Id, cancellationToken);

            if (membershipRequest == null)
                throw new NotFoundException("درخواست عضویت یافت نشد.");

            if (membershipRequest.Status != MembershipRequestStatus.Pending)
                throw new ConflictException("درخواست قبلا بررسی شده است.");

            var loginedUserMembership = await _unitOfWork.InstituteMembershipRepository.GetUserMembersShipByUserIdAsync(
                userId, membershipRequest.InstituteId, cancellationToken) ?? throw new NotFoundException();

            if (!loginedUserMembership.MembershipRoles.Any(r => r.MemberType == MemberType.Admin) &&
                !loginedUserMembership.MembershipRoles.Any(r => r.MemberType == MemberType.Founder))
                throw new UnauthorizedException("شما اجازه پردازش درخواست را ندارید.");

            var requestedUserMembership = await _unitOfWork.InstituteMembershipRepository.GetUserMembersShipByUserIdAsync(
                membershipRequest.UserId, membershipRequest.InstituteId, cancellationToken);

            if (requestedUserMembership != null)
                throw new ConflictException("این کاربر قبلا عضو آموزشگاه می باشد.");

            var result = await _unitOfWork.InstituteMembershipRepository.AddAsync(
                new ApplicationCore.Domain.InstituteManagement.InstituteMembership
                {
                    InstituteId = membershipRequest.InstituteId,
                    UserId = membershipRequest.UserId,
                    MembershipRoles = new List<ApplicationCore.Domain.InstituteManagement.InstituteMembershipRole>
                    {
                        new ApplicationCore.Domain.InstituteManagement.InstituteMembershipRole
                        {
                            MemberType = request.MemberType
                        }
                    }
                }, cancellationToken);

            membershipRequest.Status = MembershipRequestStatus.Accepted;
            _unitOfWork.MembershipRequestRepository.Update(membershipRequest);

            await _unitOfWork.CommitAsync();
            return _mapper.Map<MembershipRequestCommandResponse>(result);
        }

    }

}
