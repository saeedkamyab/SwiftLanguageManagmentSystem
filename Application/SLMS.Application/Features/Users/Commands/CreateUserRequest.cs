using MediatR;
using SLMS.Dto.User;

namespace SLMS.Application.Features.Users.Commands
{
    public class CreateUserRequest : IRequest<bool>
    {
        public required CreateUserDto User { get; set; }
    }
}
