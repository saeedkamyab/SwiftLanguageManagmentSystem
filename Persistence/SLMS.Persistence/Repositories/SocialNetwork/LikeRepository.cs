using Microsoft.EntityFrameworkCore;
using SLMS.Application.Contracts.SocialNetwork;
using SLMS.ApplicationCore.Domain.SocialNetwork;
using SLMS.Persistence.Repositories.Common;

namespace SLMS.Persistence.Repositories.SocialNetwork
{
    public class LikeRepository : BaseRepository<Like>, ILikeRepository
    {
        private readonly SLMSDbContext _context;

        public LikeRepository(SLMSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Like> GetByUserAndPostAsync(Guid PostId, Guid UserId)
        {
            return await _context.Set<Like>().FirstOrDefaultAsync(x => x.PostId == PostId && x.UserId == UserId);

        }

    }
}
