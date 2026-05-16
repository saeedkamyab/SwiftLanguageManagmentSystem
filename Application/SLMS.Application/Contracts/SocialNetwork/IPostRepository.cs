using SLMS.Application.Contracts.Persistance;
using SLMS.ApplicationCore.Domain.SocialNetwork;
using System.Linq.Expressions;

namespace SLMS.Application.Contracts.SocialNetwork
{
    public interface IPostRepository:IBaseRepository<Post>
    {
        IQueryable<Post> GetQueryable(Expression<Func<Post, bool>> predicate);
    }
}
