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

        public async Task<bool> ExistsByEmailAsync(string email)
        {
           var user= await _context.Set<User>().FirstOrDefaultAsync(x => x.Email == email);
            if (user != null)
                return true;
            return false;
        }

        public async Task<bool> ExistsByUserNameAsync(string userName)
        {
            var user = await _context.Set<User>().FirstOrDefaultAsync(x=>x.UserName== userName);
            if (user != null)
                return true;
            return false;
        }
    }
}
