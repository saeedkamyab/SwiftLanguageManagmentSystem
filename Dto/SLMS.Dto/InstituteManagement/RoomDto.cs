namespace SLMS.Dto.InstituteManagement
{
    public class RoomDto : BaseDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        public Guid InstituteId { get; set; }
        public InstituteDto Institute {  get; set; }
        public ICollection<TermCourseDto> TermCourses {  get; set; }
    }
}
