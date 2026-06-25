using MediatR;

namespace SLMS.Application.Features.InstituteManagement.Room.Queries
{
    public class GetRoomRequest:IRequest<RoomQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
