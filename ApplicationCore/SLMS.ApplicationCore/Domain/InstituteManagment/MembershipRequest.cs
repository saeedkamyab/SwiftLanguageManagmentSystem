namespace SLMS.ApplicationCore.Domain.InstituteManagment
{
    public class MembershipRequest : BaseEntity
    {
        public DateTime RequestDate { get; set; }
        public Guid PersonId { get; set; }
    }
}
