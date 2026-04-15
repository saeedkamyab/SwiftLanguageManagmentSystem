using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.UserManagement;
using SLMS.Shared.Enums;

namespace SLMS.Persistence.ModelsConfigurations.UserManagment
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> message)
        {
            message.Property(m=>m.Content).HasMaxLength(800);
            message.Property(m=>m.ImageUrl).HasMaxLength(1500).IsRequired(false);
            message.Property(m=>m.VideoUrl).HasMaxLength(1500).IsRequired(false);
            message.Property(m=>m.SentAt).HasDefaultValue(DateTime.Now);
            message.Property(m=>m.Status).HasDefaultValue(MessageStatus.Sent);


            message.HasOne(m => m.Conversation)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ConversationId)
;
            message.HasOne(m => m.SenderUser)
                        .WithMany(u => u.Messages)
                        .HasForeignKey(m => m.SenderUserId)
;        }
    }
}
