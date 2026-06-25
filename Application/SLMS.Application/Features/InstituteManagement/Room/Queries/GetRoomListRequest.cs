using MediatR;
using SLMS.Shared;

namespace SLMS.Application.Features.InstituteManagement.Room.Queries
{
    public class GetRoomListRequest:IRequest<PagedResult<RoomQueryResponse>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SearchTerm { get; set; }
    }
}
