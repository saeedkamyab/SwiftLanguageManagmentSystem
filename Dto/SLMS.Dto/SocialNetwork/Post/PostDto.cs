using SLMS.Dto.SocialNetwork.Comments;
using SLMS.Dto.User;

namespace SLMS.Dto.SocialNetwork.Post
{
    public class PostDto : BaseDto
    {
        public string Caption { get; set; } = string.Empty;
        public Guid PostOwnerId { get; set; }
        public UserDto PostOwner { get; set; } = null!;
        public PostMediaDto? PostMedia { get; set; }
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }
        public int SharesCount { get; set; }
        public int BookmarksCount { get; set; }


        public ICollection<LikeDto> Likes { get; set; } = [];
        public ICollection<BookmarkDto> Bookmarks { get; set; } = [];
        public ICollection<CommentDto> Comments { get; set; } = [];


    }
}
