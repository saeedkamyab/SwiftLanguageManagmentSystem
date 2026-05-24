using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SLMS.Application.Contracts.Persistance;
using SLMS.ApplicationCore.Domain.SocialNetwork;
using SLMS.Dto.SocialNetwork;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace SLMS.Application.Features.SocialNetwork.Posts.Queries
{
    public class GetPostListRequestHandler : IRequestHandler<GetPostListRequest, PagedResult<PostSummaryDto>>
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
                var currentUserId = Guid.Parse("007ed1b0-50a4-4585-a8af-9f36bb896010");
                var query = _unitofwork.PostRepository.GetQueryable(x => x.IsDeleted == false);
                if (request.OnlyMyFollowings)
                {
                    var followingUserIds = await _unitofwork.FollowRepository.GetQueryable()
                            .Where(x => x.FollowerUserId == currentUserId)
                            .Select(x => x.FollowingUserId)
                            .ToListAsync(cancellationToken);
                    if (followingUserIds.Any())
                    {
                        query = query.Where(p => followingUserIds.Contains(p.PostOwnerId));
                    }
                    else
                    {
                        // هیچ‌کس را فالو نکرده → خروجی خالی
                        return new PagedResult<PostSummaryDto>(
                            new List<PostSummaryDto>(),
                            0,
                            request.PageNumber,
                            request.PageSize,
                            request.OnlyMyFollowings);
                    }
                }

                if (!string.IsNullOrWhiteSpace(request.SearchTerm))
                {
                    query = query.Where(p => p.Caption.Contains(request.SearchTerm));
                }




                var totalCount = await query.CountAsync(cancellationToken);

                var items = await query
           .OrderByDescending(p => p.CreateDate)
           .Skip((request.PageNumber - 1) * request.PageSize)
           .Take(request.PageSize)
           .ProjectTo<PostSummaryDto>(_mapper.ConfigurationProvider)
           .ToListAsync(cancellationToken);

                if (items.Any())
                {
                    var postIds = items.Select(p => p.Id).ToList();


                    var likedPostIds = await _unitofwork.LikeRepository.GetQueryable()
            .Where(l => postIds.Contains(l.PostId) && l.UserId == currentUserId)
            .Select(l => l.PostId)
            .ToListAsync(cancellationToken);

                    var bookmarkedPostIds = await _unitofwork.BookmarkRepository.GetQueryable()
            .Where(b => postIds.Contains(b.PostId) && b.UserId == currentUserId)
            .Select(b => b.PostId)
            .ToListAsync(cancellationToken);

                    //if (request.OnlyMyFollowings == true)
                    //{
                    //    var followingUserIds = await _unitofwork.FollowRepository.GetQueryable()
                    //        .Where(x => x.FollowerUserId == currentUserId)
                    //        .Select(x => x.FollowingUserId)
                    //        .ToListAsync(cancellationToken);
                    //    if (followingUserIds.Any())
                    //    {
                    //        items = items.Where(x => followingUserIds.Contains(x.OwnerId)).ToList();
                    //    }
                    //}
                    //var likes = await _unitofwork.LikeRepository.GetAllAsync(x => postIds.Contains(x.PostId));

                    //var bookmarks = await _unitofwork.BookmarkRepository.GetAllAsync(x => postIds.Contains(x.PostId));

                    //var likedPostIds = likes
                    //    .Select(l => l.PostId).ToList();

                    //var bookmarkedPostIds = bookmarks
                    //.Select(l => l.PostId).ToList();


                    foreach (var item in items)
                    {
                        item.IsLikedByCurrentUser = likedPostIds.Contains(item.Id);
                        item.IsBookmarkedByCurrentUser = bookmarkedPostIds.Contains(item.Id);
                    }
                }
                // 6️⃣ برگرداندن نتیجه Paged
                return new PagedResult<PostSummaryDto>(
                    items,
                    totalCount,
                    request.PageNumber,
                    request.PageSize,
                    request.OnlyMyFollowings);
            }
            catch
            {
                throw;
            }
        }
    }
}
