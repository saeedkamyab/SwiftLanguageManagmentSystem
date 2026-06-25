using MediatR;
using SLMS.Shared;

namespace SLMS.Application.Features.InstituteManagement.TermCourse.Queries
{
    public class GetTermCourseListRequest:IRequest<PagedResult<TermCourseQueryResponse>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SearchTerm { get; set; }
    }
}
