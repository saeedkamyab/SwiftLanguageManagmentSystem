using MediatR;
using SLMS.Dto.User;

namespace SLMS.Application.Features.Commands.User.Requests
{
    public class UpdateUserRequest : IRequest<bool>
    {
        public required UpdateUserDto User { get; set; }
    }
}
