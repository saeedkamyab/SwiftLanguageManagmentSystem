using SLMS.Dto.InstituteManagement;
using System.Xml.Linq;

namespace SLMS.Dto.UserManagement
{
    public class UserDto : BaseDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FatherName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;



     public ICollection<FollowDto> Followings { get; set; } = [];
     public ICollection<FollowDto> Followers { get; set; } = [];
     public ICollection<PostDto> Posts { get; set; } = [];
     public ICollection<LikeDto> Likes { get; set; } = [];
     public ICollection<CommentDto> Comments { get; set; } = [];
     public ICollection<MessageDto> Messages { get; set; } = [];
     public ICollection<ConversationMemberDto> ConversationMembers { get; set; } = [];
     public ICollection<InstituteMembershipDto> InstituteMemberships { get; set; } = [];
     public ICollection<MembershipRequestDto> MembershipRequests { get; set; } = [];
    }
}
