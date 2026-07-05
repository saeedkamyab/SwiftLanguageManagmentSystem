namespace SLMS.Dto.InstituteManagement
{
    public class CreateInstituteDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Guid> CategoryIds { get; set; } = [];
    }
}
