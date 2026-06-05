using MediatR;
using SLMS.Dto.User;

namespace SLMS.Application.Features.Users.Commands
{
    public class UpdateUserRequest : IRequest<UserDto>
    {
        public required UpdateUserDto User { get; set; }
    }
}
