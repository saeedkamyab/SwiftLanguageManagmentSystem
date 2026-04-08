using SLMS.ApplicationCore.Domain.UserManagement;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    public class MembershipRequest : BaseEntity
    {
        public DateTime RequestDate { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public Guid InstituteId { get; set; }
        [ForeignKey(nameof(InstituteId))]
        public Institute Institute { get; set; }
    }
}
