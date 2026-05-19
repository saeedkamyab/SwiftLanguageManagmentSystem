using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.SocialNetwork
{
    [Table("Comment", Schema = "SocialNetwork")]
    public class Comment : BaseEntity
    {
       
        public string CommentContext { get; set; }=string.Empty;

        public Guid PostId { get; set; }
        public Post Post { get; set; }
       
        public Guid? ParentId { get; set; }
        public Comment? Parent { get; set; }
       
        public Guid UserId { get; set; }
        public Domain.User.User User { get; set; }

        public ICollection<Comment> ChildComments { get; set; }
    }
}
