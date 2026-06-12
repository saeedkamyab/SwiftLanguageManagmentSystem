using MediatR;

namespace SLMS.Application.Features.SocialNetwork.Posts.Commands
{
    public class UpdatePostCommand : IRequest<PostCommandResponse>
    {
        public string Caption { get; set; } = string.Empty;
    }
}
