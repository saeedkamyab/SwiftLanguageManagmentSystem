using SLMS.Dto.SocialNetwork;
using SLMS.WebApplicationComponents.Services.Base;
using SLMS.WebApplicationComponents.Services.SocialNetwork.Interface;

namespace SLMS.WebApplicationComponents.Services.SocialNetwork
{

    public class PostService : IPostService
    {
        private readonly BaseApiService _baseApiService;
        public PostService(BaseApiService baseApiService)
        {
            _baseApiService = baseApiService;
        }

        public async Task<PagedResult<PostSummaryDto>> GetAllPostsAsync(PostListQuery postListQuery)
        {
            var url = BuildUrl("/api/v1/Post", postListQuery);
            return await _baseApiService.GetAllAsync<PagedResult<PostSummaryDto>>(url);
        }
        public async Task ToggleLikeAsync(Guid postId)
        {
            await _baseApiService.PostAsync($"api/v1/Post/{postId}/toggle-like");
        }
        public async Task ToggleBookmarkAsync(Guid postId)
        {
            await _baseApiService.PostAsync($"api/v1/Post/{postId}/toggle-bookmark");
        }

        private static string BuildUrl(string baseUrl, PostListQuery query)
        {
            var parts = new List<string>
             {
                $"pageNumber={query.PageNumber}",
                $"pageSize={query.PageSize}"
            };
            if (query.OnlyMyFollowings.HasValue)
                parts.Add($"onlyMyFollowings={query.OnlyMyFollowings.Value.ToString().ToLowerInvariant()}");
            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
                parts.Add($"searchTerm={Uri.EscapeDataString(query.SearchTerm)}");
            return $"{baseUrl}?{string.Join("&", parts)}";

        }

    }


}
