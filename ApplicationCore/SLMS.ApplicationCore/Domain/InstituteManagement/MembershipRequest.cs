namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    public class MembershipRequest : BaseEntity
    {
        public DateTime RequestDate { get; set; }
        public Guid PersonId { get; set; }
        public Guid InstituteId { get; set; }
    }
}
