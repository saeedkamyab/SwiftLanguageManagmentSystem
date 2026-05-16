using MediatR;
using SLMS.Dto.SocialNetwork;

namespace SLMS.Application.Features.Queries.SocialNetwork.Requests
{
    public class GetPostRequest:IRequest<PostDto>
    {
        public Guid Id { get; set; }
    }
}
