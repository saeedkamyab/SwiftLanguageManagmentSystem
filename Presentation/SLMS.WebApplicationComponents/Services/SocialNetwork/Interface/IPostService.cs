using SLMS.Dto.SocialNetwork;

namespace SLMS.WebApplicationComponents.Services.SocialNetwork.Interface
{
    public interface IPostService
    {
        Task<PagedResult<PostSummaryDto>> GetAllPostsAsync(PostListQuery postListQuery);
        Task ToggleLikeAsync(Guid postId);
        Task ToggleBookmarkAsync(Guid postId);
    }
}
