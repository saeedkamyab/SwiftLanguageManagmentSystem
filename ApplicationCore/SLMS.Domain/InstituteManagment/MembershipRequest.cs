namespace SLMS.Domain.InstituteManagment
{
    public class MembershipRequest : BaseEntity
    {
        public DateTime RequestDate { get; set; }
        public Guid PersonId { get; set; }
    }
}
