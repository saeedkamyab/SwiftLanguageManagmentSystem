namespace SLMS.Application.Features.SocialNetwork.Posts.Queries
{
    public class GetPostListQueryResponse
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string Caption { get; set; } = string.Empty;

        public Guid OwnerId { get; set; }
    
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public string OwnerAvatarUrl { get; set; }
        public string OwnerFullName => $"{OwnerFirstName} {OwnerLastName}";

        public int LikesCount { get; set; }
        public int SharesCount { get; set; }
        public int CommentsCount { get; set; }
        public int BookmarksCount { get; set; }

        public bool IsLikedByCurrentUser { get; set; }
        public bool IsBookmarkedByCurrentUser { get; set; }
    }
}
