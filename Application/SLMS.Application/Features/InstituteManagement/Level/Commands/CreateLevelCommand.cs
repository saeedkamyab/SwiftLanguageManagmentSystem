using MediatR;
using SLMS.Application.Contracts.Identity;

namespace SLMS.Application.Features.InstituteManagement.Level.Commands
{
    public class CreateLevelCommand : IRequest<LevelCommandResponse>,IAuthorizedRequest
    {
        public string Title { get; set; } = string.Empty;
        public Guid InstituteId { get; set; }
    }
}
