using MediatR;
using SLMS.Application.Contracts.Identity;

namespace SLMS.Application.Features.InstituteManagement.TermCourse.Commands
{
    public class DeleteTermCourseCommand:IRequest<bool>,IAuthorizedRequest
    {
        public Guid Id { get; set; }
    }
}
