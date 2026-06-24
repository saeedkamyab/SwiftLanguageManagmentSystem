using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SLMS.Application.Contracts.Persistance;
using SLMS.Shared;

namespace SLMS.Application.Features.InstituteManagement.Level.Queries
{
    public class GetLevelListRequestHandler : IRequestHandler<GetLevelListRequest, PagedResult<LevelQueryResponse>>
    {
        IMapper _mapper;
        IUnitOfWork _unitofwork;

        public GetLevelListRequestHandler(IMapper mapper, IUnitOfWork unitofwork)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
        }

        public async Task<PagedResult<LevelQueryResponse>> Handle(GetLevelListRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _unitofwork.LevelRepository.GetQueryable();

                if (!string.IsNullOrWhiteSpace(request.SearchTerm))
                {
                    request.SearchTerm = request.SearchTerm.Trim();

                    query = query.Where(p =>
                        p.Title.Contains(request.SearchTerm));
                }
                var totalCount = await query.CountAsync(cancellationToken);

                var items = await query
         .OrderByDescending(p => p.CreateDate)
         .Skip((request.PageNumber - 1) * request.PageSize)
         .Take(request.PageSize)
         .ProjectTo<LevelQueryResponse>(_mapper.ConfigurationProvider)
         .ToListAsync(cancellationToken);

                return new PagedResult<LevelQueryResponse>(
                    items,
                    totalCount,
                    request.PageNumber,
                    request.PageSize
                    );
            }
            catch
            {
                throw;
            }
        }
    }
}
