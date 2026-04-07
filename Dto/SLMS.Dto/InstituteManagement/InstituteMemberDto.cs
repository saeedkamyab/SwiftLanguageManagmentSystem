using SLMS.Shared.Enums;

namespace SLMS.Dto.InstituteManagement
{
    public class InstituteMembershipDto : BaseDto
    {
        public Guid InstituteId { get; set; }
        public Guid PersonId { get; set; }
        public MemberType MemberType { get; set; }
    }
}
