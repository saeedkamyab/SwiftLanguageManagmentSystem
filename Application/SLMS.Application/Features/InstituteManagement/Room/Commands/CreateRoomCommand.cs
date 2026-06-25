using MediatR;
using SLMS.Application.Contracts.Identity;

namespace SLMS.Application.Features.InstituteManagement.Room.Commands
{
    public class CreateRoomCommand : IRequest<RoomCommandResponse>,IAuthorizedRequest
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid InstituteId { get; set; }
    }
}
