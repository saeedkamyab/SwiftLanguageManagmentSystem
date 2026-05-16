using MediatR;
using SLMS.Dto.SocialNetwork;

namespace SLMS.Application.Features.Queries.SocialNetwork.Requests
{
    public class GetPostRecyclingbinListRequest:IRequest<List<PostDto>>
    {
    }
}
