using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SLMS.Application.Contracts.Persistance;
using SLMS.Shared;

namespace SLMS.Application.Features.InstituteManagement.Certificate.Queries
{
    public class GetCertificatesQueryHandler : IRequestHandler<GetCertificatesQuery, PagedResult<CertificateQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetCertificatesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResult<CertificateQueryResponse>> Handle(GetCertificatesQuery request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.CertificateRepository.GetQueryable();

            if (request.ClassificationId.HasValue)
                query = query.Where(x => x.ClassificationId == request.ClassificationId.Value);

            if (request.Status.HasValue)
                query = query.Where(x => x.Status == request.Status.Value);

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderByDescending(x => x.CreateDate)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ProjectTo<CertificateQueryResponse>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PagedResult<CertificateQueryResponse>(
                items,
                totalCount,
                request.PageNumber,
                request.PageSize);
        }
    }
}
