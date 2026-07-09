using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SLMS.Application.Contracts.Persistance;
using SLMS.Shared;

namespace SLMS.Application.Features.InstituteManagement.AbsentPresent.Queries
{
    public class GetAbsentPresentsQueryHandler : IRequestHandler<GetAbsentPresentsQuery, PagedResult<AbsentPresentQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAbsentPresentsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResult<AbsentPresentQueryResponse>> Handle(GetAbsentPresentsQuery request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.AbsentPresentRepository.GetQueryable();

            if (request.ClassifictionId.HasValue)
                query = query.Where(x => x.ClassifictionId == request.ClassifictionId.Value);

            if (request.IsPresent.HasValue)
                query = query.Where(x => x.IsPresent == request.IsPresent.Value);

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderByDescending(x => x.Date)
                .ThenByDescending(x => x.SessionNumber)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ProjectTo<AbsentPresentQueryResponse>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PagedResult<AbsentPresentQueryResponse>(
                items,
                totalCount,
                request.PageNumber,
                request.PageSize);
        }
    }
}
