using SLMS.Application.Contracts.Persistance;
using SLMS.ApplicationCore.Domain.PersonManagement;
using SLMS.Persistence.Repositories.Common;

namespace SLMS.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SLMSDbContext _context;
        private bool _disposed;
        #region Fields -----------------------------------------------------------

        #region PersonManagement
        private readonly Lazy<IBaseRepository<Person>> _personRepository;

        #endregion


        #endregion

        #region Properties -------------------------------------------------------

        #region PersonManagement
        public IBaseRepository<Person> PersonRepository
      => _personRepository.Value ;

        #endregion



        #endregion

        public UnitOfWork(SLMSDbContext context)
        {
            _context = context;
            _personRepository = new Lazy<IBaseRepository<Person>>(
       () => new BaseRepository<Person>(_context));
        }
        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
        public void Dispose()
        {
            if (!_disposed)
            {
                _context.Dispose();
                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }

    }
}
