using SLMS.ApplicationCore.Domain.UserManagement;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    public class MembershipRequest : BaseEntity
    {
        public DateTime RequestDate { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid InstituteId { get; set; }
        public Institute Institute { get; set; }
    }
}
