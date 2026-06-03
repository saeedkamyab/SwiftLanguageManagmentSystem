using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.SocialNetwork
{
    [Table("Post", Schema = "SocialNetwork")]
    public class Post : BaseEntity
    {
        public string Caption { get; set; } = string.Empty;
        public Guid PostOwnerId { get; set; }
        public Domain.User.User PostOwner { get; set; } = null!;
        public PostMedia? PostMedia { get; set; }
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }
        public int SharesCount { get; set; }
        public int BookmarksCount { get; set; }


        public ICollection<Like> Likes { get; set; } = [];
        public ICollection<Bookmark> Bookmarks { get; set; }=[];
        public ICollection<Comment> Comments { get; set; } = [];
    

    }
}
