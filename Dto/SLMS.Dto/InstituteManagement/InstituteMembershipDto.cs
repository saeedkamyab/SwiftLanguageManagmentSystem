using SLMS.Dto.User;
using SLMS.Shared.Enums;

namespace SLMS.Dto.InstituteManagement
{
    public class InstituteMembershipDto : BaseDto
    {
        public MemberType MemberType { get; set; }


        public Guid InstituteId { get; set; }
        public InstituteDto Institute { get; set; }
        public Guid UserId { get; set; }
        public UserDto User { get; set; }
        public Guid LevelId { get; set; }
        public LevelDto Level { get; set; }

       public ICollection<ClassificationDto> Classifications { get; set; }
       public ICollection<InstituteMembershipGroupDto> InstituteMembershipGroups { get; set; }

    }
}
