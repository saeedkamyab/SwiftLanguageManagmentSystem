using SLMS.Application.Contracts.Persistance;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Application.Contracts.InstituteManagment
{
    public interface IMembershipRequestRepository:IBaseRepository<MembershipRequest>
    {
        public Task<bool> ExistsRequestAsync(Guid userId,Guid instituteId,CancellationToken cancellationToken);
    }
}
