using SLMS.Application.Contracts.Persistance;
using SLMS.ApplicationCore.Domain.User;

namespace SLMS.Application.Contracts.Identity
{
    public interface IUserRepository:IBaseRepository<User>
    {
        public Task<bool> ExistsByUserNameAsync(string userName,CancellationToken cancellationToken);
        public Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken);
        public Task<User?> GetByUserNameOrEmailAsync(string userNameOrEmail, CancellationToken cancellationToken);
    }
}
