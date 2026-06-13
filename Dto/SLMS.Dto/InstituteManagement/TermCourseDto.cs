using SLMS.Shared.Enums;

namespace SLMS.Dto.InstituteManagement
{
    public class TermCourseDto : BaseDto
    {
        public WeekDay WeekDay { get; set; }
        public TimeOnly Time { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public bool IsActive { get; set; }

        public Guid LevelId { get; set; }
        public LevelDto Level { get; set; } = null!;
        public Guid InstituteId { get; set; }
        public InstituteDto Institute { get; set; } = null!;
        public Guid RoomId { get; set; }
        public RoomDto Room { get; set; } = null!;

        public ICollection<ClassificationDto> Classifications { get; set; } = [];
    }
}
