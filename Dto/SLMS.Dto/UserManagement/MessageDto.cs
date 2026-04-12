using SLMS.Shared.Enums;

namespace SLMS.Dto.UserManagement
{
    public class MessageDto:BaseDto
    {
        public string Content { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } 
        public string? VideoUrl { get; set; }
      
        public DateTime SentAt { get; set; }
         public MessageStatus Status { get; set; }


        public Guid ConversationId { get; set; }
        public ConversationDto Conversation { get; set; }

        public Guid SenderUserId { get; set; }
        public UserDto SenderUser { get; set; }
    }

}
