using MediatR;
using SLMS.Dto.UserManagement;

namespace SLMS.Application.Features.Commands.UserManagement.User.Requests
{
    public class DeleteUserRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
