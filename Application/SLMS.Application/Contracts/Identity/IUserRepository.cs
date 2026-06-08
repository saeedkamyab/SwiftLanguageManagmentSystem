using SLMS.Application.Contracts.Persistance;
using SLMS.ApplicationCore.Domain.User;

namespace SLMS.Application.Contracts.Identity
{
    public interface IUserRepository:IBaseRepository<User>
    {
        public Task<bool> ExistsByUserNameAsync(string userName);
        public Task<bool> ExistsByEmailAsync(string email);
    }
}
