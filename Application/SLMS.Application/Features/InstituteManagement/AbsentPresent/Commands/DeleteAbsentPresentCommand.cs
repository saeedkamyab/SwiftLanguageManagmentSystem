using MediatR;
using SLMS.Application.Attributes;
using SLMS.Application.Contracts.Identity;
using SLMS.Shared.Enums;

namespace SLMS.Application.Features.InstituteManagement.AbsentPresent.Commands
{
    [RequireRoles(MemberType.Founder, MemberType.Admin)]
    public class DeleteAbsentPresentCommand : IRequest<bool>, IAuthorizedRequest
    {
        public Guid Id { get; set; }
        public required Guid InstituteId { get; set; }
    }
}
