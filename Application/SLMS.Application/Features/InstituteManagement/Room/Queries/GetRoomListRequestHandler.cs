using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SLMS.Application.Contracts.Persistance;
using SLMS.Shared;

namespace SLMS.Application.Features.InstituteManagement.Room.Queries
{
    public class GetRoomListRequestHandler : IRequestHandler<GetRoomListRequest, PagedResult<RoomQueryResponse>>
    {
        IMapper _mapper;
        IUnitOfWork _unitofwork;

        public GetRoomListRequestHandler(IMapper mapper, IUnitOfWork unitofwork)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
        }

        public async Task<PagedResult<RoomQueryResponse>> Handle(GetRoomListRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _unitofwork.RoomRepository.GetQueryable();

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
         .ProjectTo<RoomQueryResponse>(_mapper.ConfigurationProvider)
         .ToListAsync(cancellationToken);

                return new PagedResult<RoomQueryResponse>(
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
