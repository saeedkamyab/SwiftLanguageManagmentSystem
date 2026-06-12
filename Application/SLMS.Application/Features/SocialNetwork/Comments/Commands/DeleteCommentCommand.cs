using MediatR;

namespace SLMS.Application.Features.SocialNetwork.Comments.Commands
{
    public class DeleteCommentCommand:IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
