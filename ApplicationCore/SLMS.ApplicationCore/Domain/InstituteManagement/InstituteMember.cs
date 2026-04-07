using SLMS.ApplicationCore.Domain.UserManagement;
using SLMS.Shared.Enums;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    public class InstituteMembership : BaseEntity
    {
        public Guid InstituteId { get; set; }
        public Institute Institute { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid LevelId { get; set; }
        public Level Level { get; set; }
        public MemberType MemberType { get; set; }

    }
}
