using SLMS.Application.Contracts.Persistance;
using SLMS.ApplicationCore.Domain.SocialNetwork;

namespace SLMS.Application.Contracts.SocialNetwork
{
    public interface ILikeRepository:IBaseRepository<Like>
    {
        public Task<Like> GetByUserAndPostAsync(Guid PostId,Guid UserId);
    }
}
