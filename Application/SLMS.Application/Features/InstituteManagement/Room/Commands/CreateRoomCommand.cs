using MediatR;
using SLMS.Application.Attributes;
using SLMS.Application.Contracts.Identity;
using SLMS.Shared.Enums;

namespace SLMS.Application.Features.InstituteManagement.Room.Commands
{
    [RequireRoles(MemberType.Founder, MemberType.Admin)]
    public class CreateRoomCommand : IRequest<RoomCommandResponse>,IAuthorizedRequest
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public required Guid InstituteId { get; set; }
    }
}
