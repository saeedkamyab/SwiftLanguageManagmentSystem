using Microsoft.EntityFrameworkCore;
using SLMS.Application.Contracts.SocialNetwork;
using SLMS.ApplicationCore.Domain.SocialNetwork;
using SLMS.Persistence.Repositories.Common;
using System.Linq.Expressions;

namespace SLMS.Persistence.Repositories.SocialNetwork
{
    public class PostRepository:BaseRepository<Post>,IPostRepository
    {
        private readonly SLMSDbContext _context;

        public PostRepository(SLMSDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Post> GetQueryable(Expression<Func<Post, bool>> predicate)
        {
            return _context.Set<Post>()
                .Where(predicate)
                .AsNoTracking();
        }
    }
}
