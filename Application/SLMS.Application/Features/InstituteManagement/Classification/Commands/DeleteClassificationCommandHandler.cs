using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;

namespace SLMS.Application.Features.InstituteManagement.Classification.Commands
{
    public class DeleteClassificationCommandHandler : IRequestHandler<DeleteClassificationCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteClassificationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteClassificationCommand request, CancellationToken cancellationToken)
        {
            var classification = await _unitOfWork.ClassificationRepository.GetByIdWithAbsentPresentCertificate(request.Id, cancellationToken);

            if (classification == null)
                throw new NotFoundException(nameof(Level),request.Id);

            if (classification.Certificate != null)
                throw new ConflictException("امکان حذف این کلاس بندی وجود ندارد");

            await _unitOfWork.ClassificationRepository.SoftDeleteAsync(request.Id, cancellationToken);
            await _unitOfWork.CommitAsync();

            return true;

        }
    }
}
