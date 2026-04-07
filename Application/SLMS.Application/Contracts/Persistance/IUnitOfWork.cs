using SLMS.ApplicationCore.Domain.UserManagement;

namespace SLMS.Application.Contracts.Persistance
{
    public interface IUnitOfWork
    {
        #region UserManagement
        IBaseRepository<User> UserRepository { get; }
        #endregion


        #region InstituteManagement

        #endregion
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
