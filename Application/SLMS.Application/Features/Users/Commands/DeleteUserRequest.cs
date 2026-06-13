using MediatR;

namespace SLMS.Application.Features.Users.Commands
{
    public class DeleteUserRequest : IRequest<bool>
    {
        public required Guid Id { get; set; }
    }
}
