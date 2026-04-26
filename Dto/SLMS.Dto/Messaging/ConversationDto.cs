namespace SLMS.Dto.Messaging
{
  
    public class ConversationDto:BaseDto
    {
        public DateTime LastMessageTimestamp { get; set; }
        public ICollection<ConversationMemberDto> ConversationMembers { get; set; } = [];
        public ICollection<MessageDto> Messages { get; set; } = [];
    }
}
