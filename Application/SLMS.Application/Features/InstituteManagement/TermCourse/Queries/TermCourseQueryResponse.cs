namespace SLMS.Application.Features.InstituteManagement.TermCourse.Queries
{
    public class TermCourseQueryResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
