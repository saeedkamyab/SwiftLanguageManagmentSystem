using SLMS.Dto.SocialNetwork.Comments;

namespace SLMS.WebApplicationComponents.Services.SocialNetwork.Interface
{
    public interface ICommentService
    {
        Task<List<CommentDto>> GetAllCommentsAsync(Guid postId);
    }
}
