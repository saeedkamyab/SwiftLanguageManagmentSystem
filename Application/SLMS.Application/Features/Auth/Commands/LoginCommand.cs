using MediatR;
using SLMS.Dto.User;

namespace SLMS.Application.Features.Auth.Commands
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string UserNameOrEmail { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
