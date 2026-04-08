using System;
using System.Collections.Generic;
using System.Text;

namespace SLMS.ApplicationCore.Domain.UserManagement
{
    public class Conversation:BaseEntity
    {
        public DateTime LastMessageTimestamp { get; set; }
        public ICollection<ConversationMembers> ConversationMembers { get; set; } = [];
        public ICollection<Message> Messages { get; set; } = [];
    }
}
