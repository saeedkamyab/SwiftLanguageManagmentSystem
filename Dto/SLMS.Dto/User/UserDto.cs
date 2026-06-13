namespace SLMS.Dto.User
{
    public class UserDto : UpdateUserDto
    {

        public string PasswordHash { get; set; } = string.Empty;
        public Guid SecurityStamp { get; set; }
        public DateTime? LastLoginDate { get; set; }


      



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
