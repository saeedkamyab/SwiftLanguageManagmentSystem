using SLMS.Dto.UserManagement;

namespace SLMS.Dto.InstituteManagement
{
    public class MembershipRequestDto : BaseDto
    {
        public DateTime RequestDate { get; set; }

        public Guid UserId { get; set; }
        public UserDto User { get; set; }
        public Guid InstituteId { get; set; }
        public InstituteDto Institute { get; set; }
    }
}
