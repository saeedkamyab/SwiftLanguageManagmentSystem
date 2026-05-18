using MediatR;
using SLMS.Dto.User;

namespace SLMS.Application.Features.Users.Queries
{
    public class GetUserRequest:IRequest<UserDto>
    {
        public Guid Id { get; set; }
    }
}
