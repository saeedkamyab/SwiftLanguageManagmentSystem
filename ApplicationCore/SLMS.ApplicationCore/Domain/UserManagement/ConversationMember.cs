using System;
using System.Collections.Generic;
using System.Text;

namespace SLMS.ApplicationCore.Domain.UserManagement
{
    public class ConversationMember
    {
        public Guid ConversationId { get; set; }
        public Conversation Conversation { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime? LastReadMessageTimestamp { get; set; }
    }
}
