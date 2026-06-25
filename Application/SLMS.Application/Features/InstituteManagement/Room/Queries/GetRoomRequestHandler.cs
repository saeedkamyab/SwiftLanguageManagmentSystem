using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;

namespace SLMS.Application.Features.InstituteManagement.Room.Queries
{
    public class GetRoomRequestHandler : IRequestHandler<GetRoomRequest, RoomQueryResponse>
    {
        IMapper _mapper;
        IUnitOfWork _unitofwork;

        public GetRoomRequestHandler(IMapper mapper, IUnitOfWork unitofwork)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
        }

        public async Task<RoomQueryResponse> Handle(GetRoomRequest request, CancellationToken cancellationToken)
        {
            var room = await _unitofwork.RoomRepository.GetByIdAsync(request.Id, cancellationToken);
            if (room == null)
                throw new NotFoundException(nameof(Room), request.Id);

            return _mapper.Map<RoomQueryResponse>(room);
        }
    }
}
