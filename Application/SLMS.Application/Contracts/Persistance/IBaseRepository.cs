using Microsoft.EntityFrameworkCore;
using SLMS.ApplicationCore;
using SLMS.ApplicationCore.Domain.SocialNetwork;
using System.Linq.Expressions;

namespace SLMS.Application.Contracts.Persistance
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> GetByIdAsync(Guid id,CancellationToken cancellationToken=default);
        Task<IReadOnlyList<TEntity>> ListAsync(Expression<Func<TEntity, bool>>? predicate, CancellationToken cancellationToken = default,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null);

        public IQueryable<TEntity> GetQueryable();


        Task<TEntity> AddAsync(TEntity entity,CancellationToken cancellationToken);
        TEntity Update(TEntity entity);
        void HardDelete(TEntity entity);
        void HardDeleteRange(IEnumerable<TEntity> entities);



        Task SoftDelete(Guid id, CancellationToken cancellationToken);
        void SoftDeleteRange(IEnumerable<TEntity> entities);

    }
}
