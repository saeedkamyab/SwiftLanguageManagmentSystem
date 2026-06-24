using MediatR;
using SLMS.Shared;

namespace SLMS.Application.Features.InstituteManagement.Level.Queries
{
    public class GetLevelListRequest:IRequest<PagedResult<LevelQueryResponse>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SearchTerm { get; set; }
    }
}
