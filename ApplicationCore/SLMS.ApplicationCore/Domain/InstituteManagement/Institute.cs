namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    public class Institute : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Fields { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<InstituteMember> InstituteMembers { get; set; } = [];
    }
}
