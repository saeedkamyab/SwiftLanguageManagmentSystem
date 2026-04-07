namespace SLMS.Dto.InstituteManagement
{
    public class TermCourseDto : BaseDto
    {
        public Guid UserId { get; set; }
        public byte WeekDay { get; set; }
        public TimeOnly Time { get; set; }
        public Guid LevelId { get; set; }
        public Guid RoomId { get; set; }
    }
}
