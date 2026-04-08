using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    public class InstituteMembershipGroup : BaseEntity
    {
        public Guid InstituteMembershipId { get; set; }
        [ForeignKey(nameof(InstituteMembershipId))]
        public InstituteMembership InstituteMembership { get; set; }
        public Guid GroupId { get; set; }
        [ForeignKey(nameof(GroupId))]
        public Group Group { get; set; }
    }
}
