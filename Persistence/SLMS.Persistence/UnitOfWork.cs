using SLMS.Application.Contracts.Persistance;
using SLMS.ApplicationCore.Domain.UserManagement;
using SLMS.Persistence.Repositories.Common;

namespace SLMS.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SLMSDbContext _context;
        private bool _disposed;
        #region Fields -----------------------------------------------------------

        #region UserManagement
        private readonly Lazy<IBaseRepository<User>> _UserRepository;

        #endregion


        #endregion

        #region Properties -------------------------------------------------------

        #region UserManagement
        public IBaseRepository<User> UserRepository
      => _UserRepository.Value ;

        #endregion



        #endregion

        public UnitOfWork(SLMSDbContext context)
        {
            _context = context;
            _UserRepository = new Lazy<IBaseRepository<User>>(
       () => new BaseRepository<User>(_context));
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
