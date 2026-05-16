using SLMS.Dto.SocialNetwork;

namespace SLMS.WebApplicationComponents.Services.SocialNetwork.Interface
{
    public interface IPostService
    {
        Task<List<PostDto>> GetAllPostsAsync();
    }
}
