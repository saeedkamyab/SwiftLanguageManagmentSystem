using MediatR;
using SLMS.Dto.SocialNetwork.Comments;

namespace SLMS.Application.Features.SocialNetwork.Comments.Commands
{
    public class CreateCommentRequest : IRequest<CommentDto>
    {
        public required CreateCommentDto Comment { get; set; }
    }
}
