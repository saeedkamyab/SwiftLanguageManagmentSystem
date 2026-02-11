namespace SLMS.ApplicationCore.Domain.InstituteManagment
{
    public class Institute : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        public List<InstituteMember> InstituteMembers { get; set; } = [];
    }
}
