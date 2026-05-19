using SLMS.ApplicationCore;
using System.Linq.Expressions;

namespace SLMS.Application.Contracts.Persistance
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> GetByIdAsync(Guid id,CancellationToken cancellationToken=default);
        Task<IReadOnlyList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate, CancellationToken cancellationToken = default,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null);
       
        
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);



        Task SoftDelete(Guid id);
        void SoftDeleteRange(IEnumerable<TEntity> entities);

    }
}
