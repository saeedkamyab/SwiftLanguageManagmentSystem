using MediatR;
using SLMS.Application.Attributes;
using SLMS.Application.Contracts.Identity;
using SLMS.Shared.Enums;

namespace SLMS.Application.Features.InstituteManagement.Membership.Commands
{
    [RequireRoles(MemberType.Founder, MemberType.Admin)]
    public class DeactiveMembershipCommand : IRequest<bool>, IAuthorizedRequest
    {
        public Guid Id { get; set; }
        public Guid InstituteId { get; set; }
    }
}
