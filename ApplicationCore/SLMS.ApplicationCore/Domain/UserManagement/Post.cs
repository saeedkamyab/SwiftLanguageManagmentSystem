using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.UserManagement
{
    [Table("Post", Schema = "UserManagment")]
    public class Post : BaseEntity
    {
        public string Title { get; set; }=string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public Guid PostOwnerId { get; set; }
        public User PostOwner { get; set; }
       

        public ICollection<Like> Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
