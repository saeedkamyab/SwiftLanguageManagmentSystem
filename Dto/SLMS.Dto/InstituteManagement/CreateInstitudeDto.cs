namespace SLMS.Dto.InstituteManagement
{
    public class CreateInstitudeDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Guid> FieldIds { get; set; } = [];
    }
}
