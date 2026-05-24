using MediatR;
using SLMS.Dto.SocialNetwork.Post;

namespace SLMS.Application.Features.SocialNetwork.Posts.Commands
{
    public class CreatePostRequest : IRequest<bool>
    {
        public required CreatePostDto Post { get; set; }
    }
}
