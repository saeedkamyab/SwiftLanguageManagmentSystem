namespace SLMS.Dto.InstituteManagement
{
    public class InstituteDto : BaseDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        public List<InstituteMembershipDto> InstituteMemberships { get; set; } = [];
    }
}
