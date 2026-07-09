namespace SLMS.Dto.InstituteManagement
{
    public class UpdateAbsentPresentDto
    {
        public bool IsPresent { get; set; }
        public DateTime Date { get; set; }
        public int SessionNumber { get; set; }
        public string? Description { get; set; }
        public Guid ClassifictionId { get; set; }
        public Guid InstituteId { get; set; }
    }
}
