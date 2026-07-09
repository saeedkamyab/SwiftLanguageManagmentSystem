namespace SLMS.Application.Features.InstituteManagement.AbsentPresent.Commands
{
    public class AbsentPresentCommandResponse
    {
        public Guid Id { get; set; }
        public bool IsPresent { get; set; }
        public DateTime Date { get; set; }
        public int SessionNumber { get; set; }
        public string? Description { get; set; }
        public Guid ClassifictionId { get; set; }
    }
}
