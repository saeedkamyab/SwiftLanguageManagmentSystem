using SLMS.Shared.Enums;

namespace SLMS.Dto.InstituteManagment
{
    public class InstituteMembers : BaseDto
    {
        public Guid InstituteId { get; set; }
        public Guid PersonId { get; set; }
        public MemberType MemberType { get; set; }
    }
}
