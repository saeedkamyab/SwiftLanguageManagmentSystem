namespace SLMS.Application.Features.InstituteManagement.MembershipRequest.Commands
{
    public class MembershipRequestCommandResponse
    {
        public Guid Id { get; set; }
        public DateTime RequestDate { get; set; }
        public Guid UserId { get; set; }
        public Guid InstituteId { get; set; }

    }
}
