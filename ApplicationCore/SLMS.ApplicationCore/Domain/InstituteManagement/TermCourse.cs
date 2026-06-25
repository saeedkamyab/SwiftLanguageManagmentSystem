using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    [Table("TermCourse", Schema = "InstituteManagement")]
    public class TermCourse : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public bool IsActive { get; set; }
        public Guid LevelId { get; set; }
        public Level Level { get; set; } = null!;
        public Guid InstituteId { get; set; }
        public Institute? Institute { get; set; }
        public Guid RoomId { get; set; }
        public Room Room { get; set; } = null!;

        public ICollection<TermCourseSessionDay> TermCourseSessionDays { get; set; } = [];
        public ICollection<Classification> Classifications { get; set; } = [];
    }
}
