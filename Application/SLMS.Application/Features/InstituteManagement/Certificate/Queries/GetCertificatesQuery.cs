using MediatR;
using SLMS.Shared;
using SLMS.Shared.Enums;

namespace SLMS.Application.Features.InstituteManagement.Certificate.Queries
{
    public class GetCertificatesQuery : IRequest<PagedResult<CertificateQueryResponse>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public Guid? ClassificationId { get; set; }
        public CertificateStatus? Status { get; set; }
    }
}
