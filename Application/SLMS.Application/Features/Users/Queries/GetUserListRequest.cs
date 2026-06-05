using MediatR;
using SLMS.Dto;
using SLMS.Dto.User;

namespace SLMS.Application.Features.Users.Queries
{
    public class GetUserListRequest:IRequest<PagedResult<UserDto>>
    {
        public int CurrentUserId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SearchTerm { get; set; }
    }
}
