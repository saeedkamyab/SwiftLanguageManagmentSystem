using SLMS.Shared.Enums;

namespace SLMS.Domain.InstituteManagment
{
    public class InstituteMembers : BaseEntity
    {
        public Guid InstitudeId { get; set; }
        public Guid PersonId { get; set; }
        public MemberType MemberType { get; set; }
    }
}
