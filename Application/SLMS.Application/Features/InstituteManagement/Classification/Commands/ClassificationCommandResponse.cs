namespace SLMS.Application.Features.InstituteManagement.Classification.Commands
{
    public class ClassificationCommandResponse
    {
        public string Title { get; set; } = string.Empty;
        public Guid TermCourseId { get; set; }
        public Guid ClassificationMemberId { get; set; }
    }
}
