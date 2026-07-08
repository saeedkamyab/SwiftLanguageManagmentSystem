using MediatR;
using SLMS.Application.Attributes;
using SLMS.Application.Contracts.Identity;
using SLMS.Shared.Enums;

namespace SLMS.Application.Features.InstituteManagement.Classification.Commands
{
    [RequireRoles(MemberType.Founder, MemberType.Admin)]
    public class CreateClassificationCommand : IRequest<ClassificationCommandResponse>, IAuthorizedRequest
    {
        public string Title { get; set; } = string.Empty;
        public Guid TermCourseId { get; set; }
        public Guid PupilMembershipId { get; set; }
        public Guid InstituteId { get; set; }
    }
}
