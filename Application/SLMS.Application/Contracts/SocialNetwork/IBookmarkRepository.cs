using SLMS.Application.Contracts.Persistance;
using SLMS.ApplicationCore.Domain.SocialNetwork;

namespace SLMS.Application.Contracts.SocialNetwork
{
    public interface IBookmarkRepository:IBaseRepository<Bookmark>
    {
        public Task<Bookmark> GetByUserAndPostAsync(Guid PostId,Guid UserId);
    }
}
