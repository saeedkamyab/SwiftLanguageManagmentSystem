using SLMS.ApplicationCore.Domain.PersonManagement;

namespace SLMS.Application.Contracts.Persistance
{
    public interface IUnitOfWork
    {
        #region PersonManagement
        IBaseRepository<Person> PersonRepository { get; }
        #endregion


        #region InstituteManagement

        #endregion
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
