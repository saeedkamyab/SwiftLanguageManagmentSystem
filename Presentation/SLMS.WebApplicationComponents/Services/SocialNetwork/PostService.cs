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

        public async Task<PagedResult<PostSummaryDto>> GetAllPostsAsync()
        {
            return await _baseApiService.GetAllAsync<PagedResult<PostSummaryDto>>("/api/v1/Post");
        }
    }


}
