namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    public class TermCourse : BaseEntity
    {
        public Guid TeacherId { get; set; }//InstituteMemberId
        public byte WeekDay { get; set; }
        public TimeOnly Time { get; set; }
        public Guid LevelId { get; set; }
        public Guid InstituteId { get; set; }
        public Guid RoomId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
