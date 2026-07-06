using MediatR;
using SLMS.Application.Contracts.Identity;
using SLMS.Shared.Enums;

namespace SLMS.Application.Features.InstituteManagement.Institute.Commands
{
    public class UpdateInstituteCommand : IRequest<InstituteCommandResponse>,IAuthorizedRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<Guid> CategoryIds { get; set; } = [];


        

        //This is for checking member type
        public IReadOnlyCollection<MemberType> RequiredRoles =>
            new[] {
                MemberType.Founder,
                MemberType.Admin
            };

        public Guid InstituteId => Id;
    }
}
