using Microsoft.EntityFrameworkCore;
using SLMS.Application.Contracts.InstituteManagment;
using SLMS.ApplicationCore.Domain.InstituteManagement;
using SLMS.Persistence.Repositories.Common;
using SLMS.Shared.Enums;

namespace SLMS.Persistence.Repositories.InstituteManagment
{
    public class InstituteMembershipRepository : BaseRepository<InstituteMembership>, IInstituteMembershipRepository
    {
        private readonly SLMSDbContext _context;

        public InstituteMembershipRepository(SLMSDbContext context) : base(context)
        {

            _context = context;
        }
        public async Task<InstituteMembership?> GetUserMembersShipByUserIdAsync(Guid userId, Guid instituteId, 
            CancellationToken cancellationToken)
        {
            var result = await _context.Set<InstituteMembership>().Include(x => x.MembershipRoles).FirstOrDefaultAsync(
                  x => x.UserId == userId && x.InstituteId == instituteId);
            return result;
        }

        public async Task<InstituteMembership?> GetUserMembersShipByIdAsync(Guid membershipId, Guid instituteId,
          CancellationToken cancellationToken)
        {
            var result = await _context.Set<InstituteMembership>().Include(x => x.MembershipRoles).FirstOrDefaultAsync(
                  x => x.Id == membershipId && x.InstituteId == instituteId);
            return result;
        }
    }

}
