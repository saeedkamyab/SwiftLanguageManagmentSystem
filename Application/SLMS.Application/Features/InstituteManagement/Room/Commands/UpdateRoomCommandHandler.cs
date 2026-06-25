using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;

namespace SLMS.Application.Features.InstituteManagement.Room.Commands
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, RoomCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateRoomCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RoomCommandResponse> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {

            var room =await _unitOfWork.RoomRepository.GetByIdAsync(request.Id,cancellationToken);
            if (room == null)
                throw new NotFoundException(nameof(Room),request.Id);

            _mapper.Map(request, room);
            var result = _unitOfWork.RoomRepository.Update(room);
           
            await _unitOfWork.CommitAsync();
            return _mapper.Map<RoomCommandResponse>(result);

        }
    }
}
