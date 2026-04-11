using SLMS.ApplicationCore.Domain.UserManagement;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    [Table("MembershipRequest", Schema = "InstituteManagement")]
    public class MembershipRequest : BaseEntity
    {
        public DateTime RequestDate { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid InstituteId { get; set; }
        public Institute Institute { get; set; }
    }
}
