using SLMS.Application.Contracts.Persistance;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Application.Contracts.InstituteManagment
{
    public interface IInstituteMembershipRepository:IBaseRepository<InstituteMembership>
    {
        public Task<InstituteMembership?> GetUserMembersShipByUserIdAsync(
            Guid userId,Guid instituteId,CancellationToken cancellationToken);

        public Task<InstituteMembership?> GetUserMembersShipByIdAsync(
    Guid membershipId, Guid instituteId, CancellationToken cancellationToken);

    }
}
