using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SLMS.Application.Contracts.Persistance;
using SLMS.Shared;

namespace SLMS.Application.Features.InstituteManagement.TermCourse.Queries
{
    public class GetTermCourseListQueryHandler : IRequestHandler<GetTermCourseListRequest, PagedResult<TermCourseQueryResponse>>
    {
        IMapper _mapper;
        IUnitOfWork _unitofwork;

        public GetTermCourseListQueryHandler(IMapper mapper, IUnitOfWork unitofwork)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
        }

        public async Task<PagedResult<TermCourseQueryResponse>> Handle(GetTermCourseListRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _unitofwork.TermCourseRepository.GetQueryable();

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
         .ProjectTo<TermCourseQueryResponse>(_mapper.ConfigurationProvider)
         .ToListAsync(cancellationToken);

                return new PagedResult<TermCourseQueryResponse>(
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
