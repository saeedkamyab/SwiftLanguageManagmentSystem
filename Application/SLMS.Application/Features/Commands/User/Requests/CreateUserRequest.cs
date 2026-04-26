using MediatR;
using SLMS.Dto.User;

namespace SLMS.Application.Features.Commands.User.Requests
{
    public class CreateUserRequest : IRequest<bool>
    {
        public required CreateUserDto User { get; set; }
    }
}
