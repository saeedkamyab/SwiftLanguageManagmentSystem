using SLMS.Shared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    [Table("InstituteMembership", Schema = "InstituteManagement")]
    public class InstituteMembership : BaseEntity
    {
        public MemberType MemberType { get; set; }


        public Guid InstituteId { get; set; }
        public Institute Institute { get; set; }
        public Guid UserId { get; set; }
        public Domain.User.User User { get; set; }
        public Guid LevelId { get; set; }
        public Level Level { get; set; }

       public ICollection<Classification> Classifications { get; set; }
       public ICollection<InstituteMembershipGroup> InstituteMembershipGroups { get; set; }

    }
}
