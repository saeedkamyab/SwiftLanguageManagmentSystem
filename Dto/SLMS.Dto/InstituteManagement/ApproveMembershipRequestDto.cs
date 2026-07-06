using SLMS.Shared.Enums;

namespace SLMS.Dto.InstituteManagement
{
    public class ApproveMembershipRequestDto
    {
        public Guid InstituteId { get; set; }
        public MemberType MemberType { get; set; }
    }
}
