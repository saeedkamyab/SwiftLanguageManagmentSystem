using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    [Table("InstituteMembershipGroup", Schema = "InstituteManagement")]
    public class InstituteMembershipGroup : BaseEntity
    {
        public Guid InstituteMembershipId { get; set; }
        public InstituteMembership InstituteMembership { get; set; }
      
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}
