namespace SLMS.Application.Features.InstituteManagement.Institute.Queries
{
    public class InstituteQueryResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
