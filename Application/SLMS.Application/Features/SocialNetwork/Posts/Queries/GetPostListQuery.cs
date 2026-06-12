using MediatR;
using SLMS.Shared;

namespace SLMS.Application.Features.SocialNetwork.Posts.Queries
{
    public class GetPostListQuery:IRequest<PagedResult<GetPostListQueryResponse>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public bool OnlyMyFollowings { get; set; }
        public string? SearchTerm { get; set; }
    }
}
