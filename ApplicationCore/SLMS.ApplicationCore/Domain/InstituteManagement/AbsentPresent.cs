namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    public class AbsentPresent:BaseEntity
    {
        public bool Present { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
