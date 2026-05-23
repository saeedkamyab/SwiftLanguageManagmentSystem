using Microsoft.EntityFrameworkCore;
using SLMS.Application.Contracts.SocialNetwork;
using SLMS.ApplicationCore.Domain.SocialNetwork;
using SLMS.Persistence.Repositories.Common;

namespace SLMS.Persistence.Repositories.SocialNetwork
{
    public class BookmarkRepository : BaseRepository<Bookmark>, IBookmarkRepository
    {
        private readonly SLMSDbContext _context;

        public BookmarkRepository(SLMSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Bookmark> GetByUserAndPostAsync(Guid PostId, Guid UserId)
        {
            return await _context.Set<Bookmark>().FirstOrDefaultAsync(x => x.PostId == PostId && x.UserId == UserId);

        }

    }
}
