using SLMS.Dto;
using SLMS.Dto.SocialNetwork;
using SLMS.Dto.SocialNetwork.Post;
using SLMS.WebApplicationComponents.Services.Api.SocialNetwork.Interface;
using System.Net.Http.Json;

namespace SLMS.WebApplicationComponents.Services.Api.SocialNetwork
{

    public class PostService : IPostService
    {
        private readonly HttpClient _httpClient;

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PagedResult<PostSummaryDto>> GetAllPostsAsync(PostListQuery query)
        {
            var url = BuildUrl("api/v1/Post", query);
            var result = await _httpClient.GetFromJsonAsync<PagedResult<PostSummaryDto>>(url);
            return result ?? throw new InvalidOperationException("API returned empty response.");
        }
        public async Task<bool> CreatePost(CreatePostDto post)
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/Post", post);
            return response.IsSuccessStatusCode;
        }
        public async Task ToggleLikeAsync(Guid postId)
        {
            var response = await _httpClient.PostAsync($"api/v1/Post/{postId}/toggle-like", null);
            response.EnsureSuccessStatusCode();
        }
        public async Task ToggleBookmarkAsync(Guid postId)
        {
            var response = await _httpClient.PostAsync($"api/v1/Post/{postId}/toggle-bookmark", null);
            response.EnsureSuccessStatusCode();
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
