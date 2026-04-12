namespace SLMS.Dto.nstituteManagement
{
    public class InstituteMembershipGroupDto : BaseDto
    {
        public Guid InstituteMembershipId { get; set; }
        public InstituteMembershipDto InstituteMembership { get; set; }
      
        public Guid GroupId { get; set; }
        public GroupDto Group { get; set; }
    }
}
