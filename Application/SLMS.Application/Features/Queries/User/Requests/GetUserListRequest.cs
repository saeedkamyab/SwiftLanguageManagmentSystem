using MediatR;
using SLMS.Dto.User;

namespace SLMS.Application.Features.Queries.User.Requests
{
    public class GetUserListRequest:IRequest<List<UserDto>>
    {
    }
}
