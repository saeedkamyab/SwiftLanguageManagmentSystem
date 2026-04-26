using MediatR;
using SLMS.Dto.User;

namespace SLMS.Application.Features.Commands.User.Requests
{
    public class DeleteUserRequest : IRequest<bool>
    {
        public required Guid Id { get; set; }
    }
}
