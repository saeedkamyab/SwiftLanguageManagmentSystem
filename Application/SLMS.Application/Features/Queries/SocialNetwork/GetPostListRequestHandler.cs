using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Features.Queries.SocialNetwork.Requests;
using SLMS.ApplicationCore.Domain.SocialNetwork;
using SLMS.Dto.SocialNetwork;
using System.Linq.Expressions;

namespace SLMS.Application.Features.Queries.SocialNetwork
{
    public class GetPostListRequestHandler : IRequestHandler<GetPostListRequest,PagedResult<PostSummaryDto>>
    {
        IMapper _mapper;
        IUnitOfWork _unitofwork;

        public GetPostListRequestHandler(IMapper mapper, IUnitOfWork unitofwork)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
        }

        public async Task<PagedResult<PostSummaryDto>> Handle(GetPostListRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var PostList = _unitofwork.PostRepository.GetQueryable(x=>x.IsDeleted==false);
              
                if (!string.IsNullOrWhiteSpace(request.SearchTerm))
                {
                    PostList = PostList.Where(p => p.Caption.Contains(request.SearchTerm));
                }
                var totalCount = await PostList.CountAsync(cancellationToken);

                var items = await PostList
           .OrderByDescending(p => p.CreateDate)
           .Skip((request.PageNumber - 1) * request.PageSize)
           .Take(request.PageSize)
           .ProjectTo<PostSummaryDto>(_mapper.ConfigurationProvider)
           .ToListAsync(cancellationToken);

                // 5️⃣ تنظیم فیلدهای پویا (مثل IsLikedByCurrentUser)
                var postIds = items.Select(p => p.Id).ToList();
                var likes = await _unitofwork.LikeRepository.GetAllAsync(x=>postIds.Contains(x.PostId));
                var likedPostIds = likes
                    //.Where(l => postIds.Contains(l.PostId))
                    .Select(l => l.PostId).ToList();

                foreach (var item in items)
                {
                    item.IsLikedByCurrentUser = likedPostIds.Contains(item.Id);
                }
                // 6️⃣ برگرداندن نتیجه Paged
                return new PagedResult<PostSummaryDto>(
                    items,
                    totalCount,
                    request.PageNumber,
                    request.PageSize);
            }
            catch
            {
                throw;
            }
        }
    }
}
