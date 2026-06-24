using MediatR;
using SLMS.Application.Contracts.Identity;

namespace SLMS.Application.Features.InstituteManagement.Level.Commands
{
    public class DeleteLevelCommand:IRequest<bool>,IAuthorizedRequest
    {
        public Guid Id { get; set; }
    }
}
