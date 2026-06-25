namespace SLMS.Application.Features.InstituteManagement.Room.Commands
{
    public class RoomCommandResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
