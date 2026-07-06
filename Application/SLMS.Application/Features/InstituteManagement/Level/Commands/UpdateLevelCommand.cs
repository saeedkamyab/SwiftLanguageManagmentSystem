using MediatR;
using SLMS.Application.Attributes;
using SLMS.Application.Contracts.Identity;
using SLMS.Shared.Enums;

namespace SLMS.Application.Features.InstituteManagement.Level.Commands
{
    [RequireRoles(MemberType.Founder, MemberType.Admin)]
    public class UpdateLevelCommand : IRequest<LevelCommandResponse>, IAuthorizedRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public required Guid InstituteId { get; set; }
    }
}
