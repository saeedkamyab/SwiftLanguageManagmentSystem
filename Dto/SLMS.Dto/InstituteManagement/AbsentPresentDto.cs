namespace SLMS.Dto.InstituteManagement
{
    public class AbsentPresentDto:BaseDto
    {
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public int SessionNumber { get; set; }
        public string Description { get; set; } = string.Empty;

        
        public Guid ClassifictionId { get; set; }
        public ClassificationDto Classifiction { get; set; } = null!;
        
    }
}
