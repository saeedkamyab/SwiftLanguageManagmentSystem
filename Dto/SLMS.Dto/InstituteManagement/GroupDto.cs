namespace SLMS.Dto.InstituteManagement
{
    public class GroupDto : BaseDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        public Guid InstituteId { get; set; }
        public InstituteDto Institute { get; set; }
        public ICollection<InstituteMembershipGroupDto> InstituteMembershipGroups { get; set; }
    }
}
