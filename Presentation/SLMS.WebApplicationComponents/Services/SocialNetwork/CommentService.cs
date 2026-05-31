using SLMS.Dto.SocialNetwork;
using SLMS.Dto.SocialNetwork.Comments;
using SLMS.WebApplicationComponents.Services.Base;
using SLMS.WebApplicationComponents.Services.SocialNetwork.Interface;
using System.Net.Http.Json;

namespace SLMS.WebApplicationComponents.Services.SocialNetwork
{

    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CommentDto>> GetAllCommentsAsync(Guid postId)
        {
            var result= await _httpClient.GetFromJsonAsync<List<CommentDto>>($"api/v1/Comment/{postId}");
            return result ?? throw new InvalidOperationException("API returned empty response.");
        }

        public async Task<bool> SendComment(CreateCommentDto comment)
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/Comment", comment);
            return response.IsSuccessStatusCode;
        }
    }


}
