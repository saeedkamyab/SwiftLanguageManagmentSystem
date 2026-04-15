namespace SLMS.Dto.InstituteManagement
{
    public class InstituteMembershipGroupDto : BaseDto
    {
        public Guid InstituteMembershipId { get; set; }
        public InstituteMembershipDto InstituteMembership { get; set; }
      
        public Guid GroupId { get; set; }
        public GroupDto Group { get; set; }
    }
}
