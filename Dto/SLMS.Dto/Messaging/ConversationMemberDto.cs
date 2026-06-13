using SLMS.Dto.User;

namespace SLMS.Dto.Messaging
{
    public class ConversationMemberDto:BaseDto
    {
        public DateTime? LastReadMessageTimestamp { get; set; }
        
        public Guid ConversationId { get; set; }
        public ConversationDto Conversation { get; set; } = null!;  
      
        public Guid UserId { get; set; }
        public UserDto User { get; set; } = null!;
        
    }
}
