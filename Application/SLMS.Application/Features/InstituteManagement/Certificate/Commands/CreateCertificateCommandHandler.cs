using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;

namespace SLMS.Application.Features.InstituteManagement.Certificate.Commands
{
    public class CreateCertificateCommandHandler : IRequestHandler<CreateCertificateCommand, CertificateCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCertificateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CertificateCommandResponse> Handle(CreateCertificateCommand request,
            CancellationToken cancellationToken)
        {
            await CertificateCommandGuards.EnsureClassificationBelongsToInstituteAsync(
                _unitOfWork,
                request.ClassificationId,
                request.InstituteId,
                cancellationToken);

            await CertificateCommandGuards.EnsureClassificationHasNoCertificateAsync(
                _unitOfWork,
                request.ClassificationId,
                currentCertificateId: null,
                cancellationToken);

            var certificate = _mapper.Map<ApplicationCore.Domain.InstituteManagement.Certificate>(request);
            var result = await _unitOfWork.CertificateRepository.AddAsync(certificate, cancellationToken);

            await _unitOfWork.CommitAsync(cancellationToken);
            return _mapper.Map<CertificateCommandResponse>(result);
        }
    }
}
