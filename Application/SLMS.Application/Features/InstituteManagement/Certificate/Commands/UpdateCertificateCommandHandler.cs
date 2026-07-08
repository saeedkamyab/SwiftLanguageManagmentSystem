using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;

namespace SLMS.Application.Features.InstituteManagement.Certificate.Commands
{
    public class UpdateCertificateCommandHandler : IRequestHandler<UpdateCertificateCommand, CertificateCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCertificateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CertificateCommandResponse> Handle(UpdateCertificateCommand request, CancellationToken cancellationToken)
        {
            await CertificateCommandGuards.EnsureCertificateBelongsToInstituteAsync(
                _unitOfWork,
                request.Id,
                request.InstituteId,
                cancellationToken);

            await CertificateCommandGuards.EnsureClassificationBelongsToInstituteAsync(
                _unitOfWork,
                request.ClassificationId,
                request.InstituteId,
                cancellationToken);

            await CertificateCommandGuards.EnsureClassificationHasNoCertificateAsync(
                _unitOfWork,
                request.ClassificationId,
                request.Id,
                cancellationToken);

            var certificate = await _unitOfWork.CertificateRepository.GetByIdAsync(request.Id, cancellationToken);
            if (certificate == null)
                throw new NotFoundException("Certificate was not found.");

            _mapper.Map(request, certificate);
            var result = _unitOfWork.CertificateRepository.Update(certificate);

            await _unitOfWork.CommitAsync(cancellationToken);
            return _mapper.Map<CertificateCommandResponse>(result);
        }
    }
}
