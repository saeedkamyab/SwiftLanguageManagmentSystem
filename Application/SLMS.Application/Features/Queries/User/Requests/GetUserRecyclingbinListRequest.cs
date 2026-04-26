using MediatR;
using SLMS.Dto.User;

namespace SLMS.Application.Features.Queries.User.Requests
{
    public class GetUserRecyclingbinListRequest:IRequest<List<UserDto>>
    {
    }
}
