using MediatR;

namespace SLMS.Application.Features.SocialNetwork.Comments.Commands
{
    public class CreateCommentCommand : IRequest<CommentCommandResponse>
    {
        public string CommentContext { get; set; } = string.Empty;
        public Guid PostId { get; set; }
        public Guid? ParentId { get; set; }
        public Guid UserId { get; set; }
    }
}
