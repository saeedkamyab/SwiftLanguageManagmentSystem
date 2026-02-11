namespace SLMS.Application.Contracts.Persistance
{
    public interface IBaseRepository<TEntity>
    {
        Task<TEntity> GetAsync(Guid id);
        Task<IReadOnlyList<TEntity>> GetListAsync(Guid id);//IReadOnlyList says to ef don't track this by change tracker
        Task<bool> AddAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
    }
}
