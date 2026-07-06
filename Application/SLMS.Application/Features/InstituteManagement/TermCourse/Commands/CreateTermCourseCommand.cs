using MediatR;
using SLMS.Application.Attributes;
using SLMS.Application.Contracts.Identity;
using SLMS.Shared.Enums;

namespace SLMS.Application.Features.InstituteManagement.TermCourse.Commands
{
    [RequireRoles(MemberType.Founder, MemberType.Admin)]
    public class CreateTermCourseCommand : IRequest<TermCourseCommandResponse>, IAuthorizedRequest
    {
        public string Title { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public Guid LevelId { get; set; }
        public required Guid InstituteId { get; set; }
        public Guid RoomId { get; set; }
        public Guid TeacherId { get; set; }

        public List<WeekDay> WeekDays { get; set; } = [];
    }
}
