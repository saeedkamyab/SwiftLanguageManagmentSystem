using SLMS.ApplicationCore.Domain.InstituteManagement;
using SLMS.ApplicationCore.Domain.Messaging;
using SLMS.ApplicationCore.Domain.SocialNetwork;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.User
{
    [Table("User", Schema = "UserManagment")]
    public class User : BaseEntity
    {
        public string UserName { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Guid SecurityStamp { get; set; }
        public DateTime? LastLoginDate { get; set; }


        public string? PhoneNumber { get; set; }
        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 
        public string? FatherName { get; set; } 
        public string? NationalCode { get; set; } 
        public string? ProfileImageUrl { get; set; } 



        public ICollection<RefreshToken> RefreshTokens { get; set; } = [];
        public ICollection<Follow> Followings { get; set; } = [];
        public ICollection<Follow> Followers { get; set; } = [];
        public ICollection<Post> Posts { get; set; } = [];
        public ICollection<Like> Likes { get; set; } = [];
        public ICollection<Bookmark> Bookmarks { get; set; } = [];
        public ICollection<Comment> Comments { get; set; } = [];
        public ICollection<Message> Messages { get; set; } = [];
        public ICollection<ConversationMember> ConversationMembers { get; set; } = [];
        public ICollection<InstituteMembership> InstituteMemberships { get; set; } = [];
        public ICollection<MembershipRequest> MembershipRequests { get; set; } = [];
    }
}
