using MediatR;

namespace SLMS.Application.Features.InstituteManagement.MembershipRequest.Commands
{
    public class CreateMembershipRequestCommand:IRequest<MembershipRequestCommandResponse>
    {
        public Guid InstituteId { get; set; }
    }
}
