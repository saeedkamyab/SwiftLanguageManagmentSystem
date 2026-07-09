namespace SLMS.Application.Features.InstituteManagement.AbsentPresent.Queries
{
    public class AbsentPresentQueryResponse
    {
        public Guid Id { get; set; }
        public bool IsPresent { get; set; }
        public DateTime Date { get; set; }
        public int SessionNumber { get; set; }
        public string? Description { get; set; }
        public Guid ClassifictionId { get; set; }
    }
}
