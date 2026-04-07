using MediatR;
using SLMS.Dto.UserManagement;

namespace SLMS.Application.Features.Queries.UserManagement.Preson.Requests
{
    public class GetUserListRequest:IRequest<List<UserDto>>
    {
    }
}
