using SLMS.Dto.SocialNetwork;
using SLMS.Dto.SocialNetwork.Comments;
using SLMS.WebApplicationComponents.Services.Base;
using SLMS.WebApplicationComponents.Services.SocialNetwork.Interface;

namespace SLMS.WebApplicationComponents.Services.SocialNetwork
{

    public class CommentService : ICommentService
    {
        private readonly BaseApiService _baseApiService;
        public CommentService(BaseApiService baseApiService)
        {
            _baseApiService = baseApiService;
        }

        public async Task<List<CommentDto>> GetAllCommentsAsync(Guid postId)
        {
            return await _baseApiService.GetAllAsync<List<CommentDto>>($"/api/v1/Comment/{postId}");
        }

        public async Task<bool> SendComment(CreateCommentDto comment)
        {
            return await _baseApiService.PostAsync("/api/v1/Comment",comment);
        }
    }


}
