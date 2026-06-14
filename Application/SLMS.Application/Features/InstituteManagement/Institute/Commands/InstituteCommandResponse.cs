namespace SLMS.Application.Features.InstituteManagement.Institute.Commands
{
    public class InstituteCommandResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Fields { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
