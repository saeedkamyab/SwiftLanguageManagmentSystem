namespace SLMS.Dto.InstituteManagment
{
    public class AbsentPresentDto:BaseDto
    {
        public bool Present { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
