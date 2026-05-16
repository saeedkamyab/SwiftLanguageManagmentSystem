using MediatR;
using SLMS.Dto.SocialNetwork;

namespace SLMS.Application.Features.Queries.SocialNetwork.Requests
{
    public class GetPostListRequest:IRequest<PagedResult<PostSummaryDto>>
    {
        public int CurrentUserId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        // فیلترهای اختیاری
        //public bool? OnlyMyFollowings { get; set; }
        public string? SearchTerm { get; set; }
    }
}
