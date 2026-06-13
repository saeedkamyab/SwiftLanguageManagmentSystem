using SLMS.Shared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    [Table("InstituteMembership", Schema = "InstituteManagement")]
    public class InstituteMembership : BaseEntity
    {
        public MemberType MemberType { get; set; }
        public Guid InstituteId { get; set; }
        public Institute Institute { get; set; } = null!;
        public Guid UserId { get; set; }
        public Domain.User.User User { get; set; } = null!;

        public ICollection<Classification> Classifications { get; set; } = [];
        public ICollection<InstituteMembershipGroup> InstituteMembershipGroups { get; set; } = [];

    }
}
