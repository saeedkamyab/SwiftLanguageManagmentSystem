using MediatR;
using SLMS.Application.Contracts.Identity;

namespace SLMS.Application.Features.InstituteManagement.Room.Commands
{
    public class DeleteRoomCommand:IRequest<bool>,IAuthorizedRequest
    {
        public Guid Id { get; set; }
    }
}
