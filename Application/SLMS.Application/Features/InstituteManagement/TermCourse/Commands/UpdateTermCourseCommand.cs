using MediatR;
using SLMS.Application.Contracts.Identity;
using SLMS.Shared.Enums;

namespace SLMS.Application.Features.InstituteManagement.TermCourse.Commands
{
    public class UpdateTermCourseCommand : IRequest<TermCourseCommandResponse>, IAuthorizedRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public Guid LevelId { get; set; }
        public Guid InstituteId { get; set; }
        public Guid RoomId { get; set; }
        public Guid TeacherId { get; set; }

        public ICollection<WeekDay> WeekDays { get; set; } = [];
    }
}
