using SLMS.Shared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    [Table("InstituteMembershipRole", Schema = "InstituteManagement")]
    public class InstituteMembershipRole : BaseEntity
    {
        public MemberType MemberType { get; set; }
        public Guid InstituteMembershipId { get; set; }
        public InstituteMembership InstituteMembership { get; set; } = null!;

    }
}
