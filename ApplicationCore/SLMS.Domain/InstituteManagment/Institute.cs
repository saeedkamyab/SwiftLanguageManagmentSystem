namespace SLMS.Domain.InstituteManagment
{
    public class Institute : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        public List<InstituteMembers> InstituteMembers {  get; set; }
    }
}
