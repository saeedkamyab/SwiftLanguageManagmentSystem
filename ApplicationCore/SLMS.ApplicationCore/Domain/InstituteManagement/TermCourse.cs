using SLMS.Shared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    public class TermCourse : BaseEntity
    {
        public WeekDay WeekDay { get; set; }
        public TimeOnly Time { get; set; }
        public Guid LevelId { get; set; }
        [ForeignKey(nameof(LevelId))]
        public Level Level { get; set; }
        public Guid InstituteId { get; set; }
        [ForeignKey(nameof(InstituteId))]
        public Institute Institute { get; set; }
        public Guid RoomId { get; set; }
        [ForeignKey(nameof(RoomId))]
        public Room Room { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
