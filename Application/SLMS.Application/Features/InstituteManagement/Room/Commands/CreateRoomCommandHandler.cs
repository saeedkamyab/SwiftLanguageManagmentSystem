using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;

namespace SLMS.Application.Features.InstituteManagement.Room.Commands
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, RoomCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoomCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<RoomCommandResponse> Handle(CreateRoomCommand request,
            CancellationToken cancellationToken)
        {
            var room = _mapper.Map<ApplicationCore.Domain.InstituteManagement.Room>(request);
            var result = await _unitOfWork.RoomRepository.AddAsync(room, cancellationToken);

            await _unitOfWork.CommitAsync();
            return _mapper.Map<RoomCommandResponse>(result);

        }
    }
}
