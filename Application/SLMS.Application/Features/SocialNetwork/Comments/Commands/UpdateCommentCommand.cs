using MediatR;
using SLMS.Dto.SocialNetwork.Comments;

namespace SLMS.Application.Features.SocialNetwork.Comments.Commands
{
    public class UpdateCommentCommand : IRequest<CommentCommandResponse>
    {
        public string CommentContext { get; set; } = string.Empty;
    }
}
