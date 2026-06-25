namespace SLMS.Dto.InstituteManagement
{
    public class CreateRoomDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid InstituteId { get; set; }
    }
}
