using MediatR;


namespace SLMS.Application.Features.SocialNetwork.Posts.Commands
{
    public class ToggleBookmarkCommandRequest : IRequest<bool>
    {
        public required Guid PostId { get; set; }
    }
}
