using SLMS.ApplicationCore.Domain.UserManagement;
using SLMS.Shared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    public class InstituteMembership : BaseEntity
    {
        public Guid InstituteId { get; set; }
        [ForeignKey(nameof(InstituteId))]
        public Institute Institute { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public Guid LevelId { get; set; }
        [ForeignKey(nameof(LevelId))]
        public Level Level { get; set; }
        public MemberType MemberType { get; set; }

    }
}
