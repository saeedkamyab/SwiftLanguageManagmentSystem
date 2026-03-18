namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    public class Level : BaseEntity
    {
        public Guid InstituteId { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
