namespace SLMS.Dto.UserManagement
{
    public class ConversationMemberDto:BaseDto
    {
        public DateTime? LastReadMessageTimestamp { get; set; }
        
        public Guid ConversationId { get; set; }
        public ConversationDto Conversation { get; set; }
      
        public Guid UserId { get; set; }
        public UserDto User { get; set; }
        
    }
}
