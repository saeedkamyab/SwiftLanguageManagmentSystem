using SLMS.Shared.Enums;

namespace SLMS.Dto.InstituteManagement
{
    public class InstituteMembershipDto : BaseDto
    {
        public Guid InstituteId { get; set; }
        public Guid UserId { get; set; }
        public MemberType MemberType { get; set; }
    }
}
