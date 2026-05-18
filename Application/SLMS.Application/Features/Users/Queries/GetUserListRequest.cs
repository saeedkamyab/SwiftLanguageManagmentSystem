using MediatR;
using SLMS.Dto.User;

namespace SLMS.Application.Features.Users.Queries
{
    public class GetUserListRequest:IRequest<List<UserDto>>
    {
    }
}
