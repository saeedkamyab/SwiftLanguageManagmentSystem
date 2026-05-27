using SLMS.Shared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.Messaging
{
    [Table("Message", Schema = "Messaging")]
    public class Message:BaseEntity
    {
        public string Content { get; set; } = string.Empty;
        public MessageType MessageType { get; set; }
        public Guid ConversationId { get; set; }
        public Conversation Conversation { get; set; } = null!;
        public Guid SenderUserId { get; set; }
        public Domain.User.User SenderUser { get; set; } = null!;
         public MessageStatus Status { get; set; }


        public ICollection<ChatMessageMedia> ChatMessageMedias { get; set; } = [];
    }

}
