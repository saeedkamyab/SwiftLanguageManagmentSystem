using SLMS.Dto.SocialNetwork.Comments;
using SLMS.Dto.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.Dto.SocialNetwork
{
    public class PostSummaryDto: BaseDto
    {
        public string Caption { get; set; } = string.Empty;

        public Guid OwnerId { get; set; }
        public UserDto PostOwner { get; set; } = null!;
        public PostMediaDto? PostMedia { get; set; }



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

        [NotMapped]
        public CreateCommentDto NewComment { get; set; } = new();

        [NotMapped]
        public bool ShowComments { get; set; }

        [NotMapped]
        public List<CommentDto> Comments { get; set; } = new();
       
        [NotMapped]
        public bool IsCommentsLoaded { get; set; }

    }
}
