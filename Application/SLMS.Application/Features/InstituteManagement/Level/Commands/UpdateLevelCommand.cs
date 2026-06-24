using MediatR;
using SLMS.Application.Contracts.Identity;

namespace SLMS.Application.Features.InstituteManagement.Level.Commands
{
    public class UpdateLevelCommand : IRequest<LevelCommandResponse>, IAuthorizedRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
