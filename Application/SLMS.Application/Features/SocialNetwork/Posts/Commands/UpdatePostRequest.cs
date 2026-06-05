using MediatR;
using SLMS.Dto.SocialNetwork.Post;

namespace SLMS.Application.Features.SocialNetwork.Posts.Commands
{
    public class UpdatePostRequest : IRequest<bool>
    {
        public required UpdatePostDto Post { get; set; }
    }
}
