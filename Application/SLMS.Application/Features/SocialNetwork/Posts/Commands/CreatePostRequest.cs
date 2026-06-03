using MediatR;
using SLMS.Dto.SocialNetwork.Post;

namespace SLMS.Application.Features.SocialNetwork.Posts.Commands
{
    public class CreatePostRequest : IRequest<PostDto>
    {
        public required CreatePostDto Post { get; set; }
    }
}
