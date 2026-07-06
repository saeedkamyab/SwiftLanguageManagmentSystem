using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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
            var result = await _context.Set<InstituteMembership>().Include(x => x.MembershipRoles)
                .FirstOrDefaultAsync(x => x.UserId == userId && x.InstituteId == instituteId);
            return result;
        }

        public async Task<InstituteMembership?> GetUserMembersShipByIdAsync(Guid membershipId,
          Guid instituteId,
          CancellationToken cancellationToken)
        {
            var result = await _context.Set<InstituteMembership>().Include(x => x.MembershipRoles).FirstOrDefaultAsync(
                  x => x.Id == membershipId);
            return result;
        }

        public async Task<bool> UserHasAnyRoleAsync(Guid userId,
                Guid instituteId, IEnumerable<MemberType> roles,
                CancellationToken cancellationToken)
        {
            return await _context.Set<InstituteMembership>()
                 .Where(x =>
                        x.UserId == userId &&
                        x.InstituteId == instituteId)
                .SelectMany(x => x.MembershipRoles)
                .AnyAsync(x => roles.Contains(x.MemberType),
                          cancellationToken);
        }
    }

}
