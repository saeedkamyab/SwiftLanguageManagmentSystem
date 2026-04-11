using SLMS.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SLMS.ApplicationCore.Domain.UserManagement
{
    [Table("Message", Schema = "UserManagment")]
    public class Message:BaseEntity
    {
        public Guid ConversationId { get; set; }
        public Conversation Conversation { get; set; }
     
        public Guid SenderUserId { get; set; }
        public User SenderUser { get; set; }


        public string Content { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } 
        public string? VideoUrl { get; set; }
      
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
         public MessageStatus Status { get; set; } 
    }

}
