namespace SLMS.Domain.InstituteManagment
{
    public class TermCourse : BaseEntity
    {
        public Guid PersonId { get; set; }
        public byte WeekDay { get; set; }
        public TimeOnly Time { get; set; }
        public Guid LevelId { get; set; }
        public Guid RoomId { get; set; }
    }
}
