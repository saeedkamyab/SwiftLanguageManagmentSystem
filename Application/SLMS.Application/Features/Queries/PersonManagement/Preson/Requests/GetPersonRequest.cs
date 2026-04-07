using MediatR;
using SLMS.Dto.UserManagement;

namespace SLMS.Application.Features.Queries.UserManagement.Preson.Requests
{
    public class GetUserRequest:IRequest<UserDto>
    {
        public Guid Id { get; set; }
    }
}
