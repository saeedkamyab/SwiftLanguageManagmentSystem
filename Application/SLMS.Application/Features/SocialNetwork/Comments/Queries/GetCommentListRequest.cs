using MediatR;
using SLMS.Dto.SocialNetwork.Comments;

namespace SLMS.Application.Features.SocialNetwork.Comments.Queries
{
    public class GetCommentListRequest:IRequest<List<CommentDto>>
    {
        public Guid PostId { get; set; }
    }
}
