using SLMS.Application.Contracts.Persistance;
using SLMS.ApplicationCore.Domain.InstituteManagement;
using SLMS.Shared.Enums;

namespace SLMS.Application.Contracts.InstituteManagment
{
    public interface IInstituteMembershipRepository:IBaseRepository<InstituteMembership>
    {
        public Task<InstituteMembership?> GetUserMembersShipAsync(Guid userId,Guid instituteId,CancellationToken cancellationToken);
    }
}
