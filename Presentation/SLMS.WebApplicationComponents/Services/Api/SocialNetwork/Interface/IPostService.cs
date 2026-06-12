using SLMS.Dto;
using SLMS.Dto.SocialNetwork;
using SLMS.Dto.SocialNetwork.Comments;
using SLMS.Dto.SocialNetwork.Post;
using SLMS.Shared;

namespace SLMS.WebApplicationComponents.Services.Api.SocialNetwork.Interface
{
    public interface IPostService
    {
        Task<PagedResult<PostSummaryDto>> GetAllPostsAsync(PostListQuery postListQuery);
        Task<bool> CreatePost(CreatePostDto post);
        Task ToggleLikeAsync(Guid postId);
        Task ToggleBookmarkAsync(Guid postId);
    }
}
