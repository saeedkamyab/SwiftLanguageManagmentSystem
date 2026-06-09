using Microsoft.EntityFrameworkCore;
using SLMS.Application.Contracts.Identity;
using SLMS.ApplicationCore.Domain.User;
using SLMS.Persistence.Repositories.Common;

namespace SLMS.Persistence.Repositories.Identity
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly SLMSDbContext _context;

        public UserRepository(SLMSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _context.Set<User>()
        .AnyAsync(x => x.Email == email, cancellationToken);
        }

        public async Task<bool> ExistsByUserNameAsync(string userName, CancellationToken cancellationToken)
        {
            return await _context.Set<User>()
     .AnyAsync(x => x.UserName == userName, cancellationToken);
        }

        public async Task<User?> GetByUserNameOrEmailAsync(string userNameOrEmail, CancellationToken cancellationToken)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(u => u.UserName == userNameOrEmail ||
            u.Email == userNameOrEmail, cancellationToken);
        }
    }
}
