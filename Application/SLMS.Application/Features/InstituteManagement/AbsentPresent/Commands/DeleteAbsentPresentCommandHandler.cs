using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;

namespace SLMS.Application.Features.InstituteManagement.AbsentPresent.Commands
{
    public class DeleteAbsentPresentCommandHandler : IRequestHandler<DeleteAbsentPresentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAbsentPresentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteAbsentPresentCommand request, CancellationToken cancellationToken)
        {
            await AbsentPresentCommandGuards.EnsureAbsentPresentBelongsToInstituteAsync(
                _unitOfWork,
                request.Id,
                request.InstituteId,
                cancellationToken);

            var absentPresent = await _unitOfWork.AbsentPresentRepository.GetByIdAsync(request.Id, cancellationToken);
            if (absentPresent == null)
                throw new NotFoundException("AbsentPresent was not found.");

            await _unitOfWork.AbsentPresentRepository.SoftDeleteAsync(request.Id, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return true;
        }
    }
}
