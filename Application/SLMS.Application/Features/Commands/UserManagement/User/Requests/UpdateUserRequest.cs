using MediatR;
using SLMS.Dto.UserManagement;

namespace SLMS.Application.Features.Commands.UserManagement.User.Requests
{
    public class UpdateUserRequest : IRequest<bool>
    {
        public required UserDto User { get; set; }
    }
}
