using MediatR;
using SLMS.Dto;
using SLMS.Dto.SocialNetwork;

namespace SLMS.Application.Features.SocialNetwork.Posts.Queries
{
    public class GetPostListRequest:IRequest<PagedResult<PostSummaryDto>>
    {
        public int CurrentUserId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;


        public bool OnlyMyFollowings { get; set; }
        public string? SearchTerm { get; set; }
    }
}
