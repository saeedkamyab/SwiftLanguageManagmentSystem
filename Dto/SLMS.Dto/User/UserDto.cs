using SLMS.Dto.InstituteManagement;
using SLMS.Dto.Messaging;
using SLMS.Dto.SocialNetwork;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SLMS.Dto.User
{
    public class UserDto : UpdateUserDto
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


      
        //public ICollection<FollowDto> Followings { get; set; } = [];
        //public ICollection<FollowDto> Followers { get; set; } = [];
        //public ICollection<PostDto> Posts { get; set; } = [];
        //public ICollection<LikeDto> Likes { get; set; } = [];
        //public ICollection<CommentDto> Comments { get; set; } = [];
        //public ICollection<MessageDto> Messages { get; set; } = [];
        //public ICollection<ConversationMemberDto> ConversationMembers { get; set; } = [];
        //public ICollection<InstituteMembershipDto> InstituteMemberships { get; set; } = [];
        //public ICollection<MembershipRequestDto> MembershipRequests { get; set; } = [];
    }
}
