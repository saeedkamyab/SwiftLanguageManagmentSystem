using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;

namespace SLMS.Application.Features.InstituteManagement.Room.Commands
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRoomCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _unitOfWork.RoomRepository.GetByIdAsync(request.Id, cancellationToken);
            if (room == null)
                throw new NotFoundException(nameof(Room),request.Id);

            var result = _unitOfWork.RoomRepository.SoftDeleteAsync(request.Id, cancellationToken);
            await _unitOfWork.CommitAsync();

            return true;

        }
    }
}
