namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    public class Group : BaseEntity
    {
        public Guid InstituteId { get; set; }
        public Institute Institute { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
