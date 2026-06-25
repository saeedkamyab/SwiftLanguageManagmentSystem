using MediatR;
using SLMS.Application.Contracts.Identity;

namespace SLMS.Application.Features.InstituteManagement.Room.Commands
{
    public class UpdateRoomCommand : IRequest<RoomCommandResponse>, IAuthorizedRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
