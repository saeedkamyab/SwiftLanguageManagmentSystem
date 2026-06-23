using MediatR;

namespace SLMS.Application.Features.InstituteManagement.MembershipRequest.Commands
{
    public class RejectMembershipRequestCommand : IRequest<MembershipRequestCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
