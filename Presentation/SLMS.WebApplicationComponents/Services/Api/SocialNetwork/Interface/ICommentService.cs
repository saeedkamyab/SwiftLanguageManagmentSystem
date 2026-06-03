using SLMS.Dto.SocialNetwork.Comments;

namespace SLMS.WebApplicationComponents.Services.Api.SocialNetwork.Interface
{
    public interface ICommentService
    {
        Task<List<CommentDto>> GetAllCommentsAsync(Guid postId);
        Task<bool> SendComment(CreateCommentDto comment);
    }
}
