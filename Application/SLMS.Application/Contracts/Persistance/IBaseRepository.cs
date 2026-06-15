using SLMS.ApplicationCore;
using System.Linq.Expressions;

namespace SLMS.Application.Contracts.Persistance
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> GetByIdAsync(Guid id,CancellationToken cancellationToken);
        Task<List<TEntity>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);
        Task<IReadOnlyList<TEntity>> ListAsync(Expression<Func<TEntity, bool>>? predicate, CancellationToken cancellationToken ,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null);

        IQueryable<TEntity> GetQueryable();
        Task<bool> ExistsAsync(Guid id,CancellationToken cancellationToken);

        Task<TEntity> AddAsync(TEntity entity,CancellationToken cancellationToken);
        TEntity Update(TEntity entity);
        void HardDelete(TEntity entity);
        void HardDeleteRange(IEnumerable<TEntity> entities);



        Task SoftDelete(Guid id, CancellationToken cancellationToken);
        void SoftDeleteRange(IEnumerable<TEntity> entities);

    }
}
