using SLMS.ApplicationCore.Domain.PersonManagment;

namespace SLMS.Application.Contracts.Persistance
{
    public interface IUnitOfWork
    {
        #region PersonManagment
        IBaseRepository<Person> PersonRepository { get; }
        #endregion


        #region InstituteManagment

        #endregion

        Task<int> CommitAsync();
    }
}
