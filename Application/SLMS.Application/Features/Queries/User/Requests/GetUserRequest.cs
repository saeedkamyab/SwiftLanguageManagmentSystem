using MediatR;
using SLMS.Dto.User;

namespace SLMS.Application.Features.Queries.User.Requests
{
    public class GetUserRequest:IRequest<UserDto>
    {
        public Guid Id { get; set; }
    }
}
