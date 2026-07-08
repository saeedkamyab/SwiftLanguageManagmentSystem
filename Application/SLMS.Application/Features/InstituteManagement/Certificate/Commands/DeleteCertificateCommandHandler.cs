using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;

namespace SLMS.Application.Features.InstituteManagement.Certificate.Commands
{
    public class DeleteCertificateCommandHandler : IRequestHandler<DeleteCertificateCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCertificateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCertificateCommand request, CancellationToken cancellationToken)
        {
            await CertificateCommandGuards.EnsureCertificateBelongsToInstituteAsync(
                _unitOfWork,
                request.Id,
                request.InstituteId,
                cancellationToken);

            var certificate = await _unitOfWork.CertificateRepository.GetByIdAsync(request.Id, cancellationToken);
            if (certificate == null)
                throw new NotFoundException(nameof(Certificate), request.Id);

            await _unitOfWork.CertificateRepository.SoftDeleteAsync(request.Id, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return true;
        }
    }
}
