using MediatR;

namespace SLMS.Application.Features.InstituteManagement.Certificate.Queries
{
    public class GetCertificateByIdQuery : IRequest<CertificateQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
