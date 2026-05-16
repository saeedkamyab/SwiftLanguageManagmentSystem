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

        public async Task<List<PostDto>> GetAllPostsAsync()
        {
            return await _baseApiService.GetAllAsync<List<PostDto>>("/api/v1/Post");
        }
    }


}
