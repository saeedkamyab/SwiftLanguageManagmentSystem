using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.UserManagement
{
    [Table("User", Schema = "UserManagment")]
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FatherName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public ICollection<Follow> Followings { get; set; } = [];
        public ICollection<Follow> Followers { get; set; } = [];
        public ICollection<Post> Posts { get; set; } = [];
        public ICollection<Like> Likes { get; set; } = [];
        public ICollection<Comment> Comments { get; set; } = [];
        public ICollection<Message> Messages { get; set; } = [];
        public ICollection<ConversationMember> ConversationMembers { get; set; } = [];
    }
}
