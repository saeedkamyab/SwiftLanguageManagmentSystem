using MediatR;
using SLMS.Shared.Enums;

namespace SLMS.Application.Features.InstituteManagement.MembershipRequest.Commands
{
    public class ApproveMembershipRequestCommand : IRequest<MembershipRequestCommandResponse>
    {
        public Guid Id { get; set; }
        public MemberType MemberType { get; set; }
    }
}
