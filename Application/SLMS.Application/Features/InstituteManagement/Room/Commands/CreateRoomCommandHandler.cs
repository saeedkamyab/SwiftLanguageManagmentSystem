using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Identity;
using SLMS.Application.Contracts.Persistance;

namespace SLMS.Application.Features.InstituteManagement.Room.Commands
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, RoomCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUser;

        public CreateRoomCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ICurrentUserService currentUser)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
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
