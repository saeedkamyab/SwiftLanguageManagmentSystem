using MediatR;
using SLMS.Shared;

namespace SLMS.Application.Features.InstituteManagement.AbsentPresent.Queries
{
    public class GetAbsentPresentsQuery : IRequest<PagedResult<AbsentPresentQueryResponse>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public Guid? ClassifictionId { get; set; }
        public bool? IsPresent { get; set; }
    }
}
