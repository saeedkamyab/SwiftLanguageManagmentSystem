using Microsoft.EntityFrameworkCore;
using SLMS.Application.Contracts.InstituteManagment;
using SLMS.ApplicationCore.Domain.InstituteManagement;
using SLMS.Persistence.Repositories.Common;

namespace SLMS.Persistence.Repositories.InstituteManagment
{
    public class MembershipRequestRepository : BaseRepository<MembershipRequest>, IMembershipRequestRepository
    {
        private readonly SLMSDbContext _context;

        public MembershipRequestRepository(SLMSDbContext context) : base(context)
        {

            _context = context;
        }

        public async Task<bool> ExistsRequestAsync(Guid userId, Guid instituteId
            , CancellationToken cancellationToken = default)
        {
            var result = await _context.Set<MembershipRequest>().AnyAsync(
                 x => x.UserId == userId && x.InstituteId == instituteId
                 && (x.Status != Shared.Enums.MembershipRequestStatus.Rejected));
            return result;
        }
    }

}
