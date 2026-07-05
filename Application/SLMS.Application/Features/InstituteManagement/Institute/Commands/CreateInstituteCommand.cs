using MediatR;

namespace SLMS.Application.Features.InstituteManagement.Institute.Commands
{
    public class CreateInstituteCommand:IRequest<InstituteCommandResponse>
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<Guid> CategoryIds { get; set; } = [];
    }
}
