namespace SLMS.Application.Features.InstituteManagement.Room.Queries
{
    public class RoomQueryResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
