namespace SLMS.Dto.InstituteManagement
{
    public class InstituteMembershipGroupDto : BaseDto
    {
        public Guid InstituteMembershipId { get; set; }
        public InstituteMembershipDto InstituteMembership { get; set; } = null!;
      
        public Guid GroupId { get; set; }
        public GroupDto Group { get; set; } = null!;
    }
}
