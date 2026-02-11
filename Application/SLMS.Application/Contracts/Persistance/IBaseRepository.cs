using SLMS.ApplicationCore;

namespace SLMS.Application.Contracts.Persistance
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> GetByIdAsync(Guid id,CancellationToken cancellationToken=default);
        Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
       
        
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);



        void SoftDelete(TEntity entity);
        void SoftDeleteRange(IEnumerable<TEntity> entities);

    }
}
