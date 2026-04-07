using SLMS.ApplicationCore.Domain.PersonManagement;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    public class MembershipRequest : BaseEntity
    {
        public DateTime RequestDate { get; set; }
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public Guid InstituteId { get; set; }
        public Institute Institute { get; set; }
    }
}
