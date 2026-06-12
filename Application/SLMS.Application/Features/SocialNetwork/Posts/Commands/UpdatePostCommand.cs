using MediatR;

namespace SLMS.Application.Features.SocialNetwork.Posts.Commands
{
    public class CreatePostCommand : IRequest<PostCommandResponse>
    {
        public string Caption { get; set; } = string.Empty;
        public Guid PostOwnerId { get; set; }
        public Guid? MediaAssetId { get; set; }

    }
}
