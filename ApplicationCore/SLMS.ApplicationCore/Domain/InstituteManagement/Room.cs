namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    public class Room : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public Guid InstituteId { get; set; }
        public Institute Institute {  get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
