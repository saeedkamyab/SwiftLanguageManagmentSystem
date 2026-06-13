using MediatR;

namespace SLMS.Application.Features.Auth.Commands
{
    public class RegisterUserCommand : IRequest<RegisterUserResponse>
    {
        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
