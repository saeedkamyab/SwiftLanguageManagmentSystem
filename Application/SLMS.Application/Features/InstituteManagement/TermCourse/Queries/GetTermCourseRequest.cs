using MediatR;

namespace SLMS.Application.Features.InstituteManagement.TermCourse.Queries
{
    public class GetTermCourseRequest:IRequest<TermCourseQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
