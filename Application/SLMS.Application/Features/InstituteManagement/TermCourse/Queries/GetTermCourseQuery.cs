using MediatR;

namespace SLMS.Application.Features.InstituteManagement.TermCourse.Queries
{
    public class GetTermCourseQuery:IRequest<TermCourseQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
