using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;

namespace SLMS.Application.Features.InstituteManagement.Certificate.Queries
{
    public class GetCertificateByIdQueryHandler : IRequestHandler<GetCertificateByIdQuery, CertificateQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetCertificateByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CertificateQueryResponse> Handle(GetCertificateByIdQuery request, CancellationToken cancellationToken)
        {
            var certificate = await _unitOfWork.CertificateRepository.GetByIdAsync(request.Id, cancellationToken);
            if (certificate == null)
                throw new NotFoundException(nameof(Certificate), request.Id);

            return _mapper.Map<CertificateQueryResponse>(certificate);
        }
    }
}
