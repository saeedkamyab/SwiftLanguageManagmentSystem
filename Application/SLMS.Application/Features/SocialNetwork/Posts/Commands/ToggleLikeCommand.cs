using MediatR;


namespace SLMS.Application.Features.SocialNetwork.Posts.Commands
{
    public class ToggleLikeCommand : IRequest<bool>
    {
        public required Guid PostId { get; set; }
        public required Guid UserId { get; set; }
    }
}
