using MediatR;
using SLMS.Application.Attributes;
using SLMS.Application.Contracts.Identity;
using SLMS.Shared.Enums;

namespace SLMS.Application.Features.InstituteManagement.AbsentPresent.Commands
{
    [RequireRoles(MemberType.Founder, MemberType.Admin)]
    public class UpdateAbsentPresentCommand : IRequest<AbsentPresentCommandResponse>, IAuthorizedRequest
    {
        public Guid Id { get; set; }
        public bool IsPresent { get; set; }
        public DateTime Date { get; set; }
        public int SessionNumber { get; set; }
        public string? Description { get; set; }
        public Guid ClassifictionId { get; set; }
        public required Guid InstituteId { get; set; }
    }
}
