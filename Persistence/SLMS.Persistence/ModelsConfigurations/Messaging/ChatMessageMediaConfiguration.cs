using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.Messaging;

namespace SLMS.Persistence.ModelsConfigurations.Messaging
{
    public class ChatMessageMediaConfiguration : BaseEntityConfiguration<ChatMessageMedia>
    {
        public override void Configure(EntityTypeBuilder<ChatMessageMedia> ChatMessageMedia)
        {
            ChatMessageMedia.HasOne(m => m.Message)
                .WithMany(cmm => cmm.ChatMessageMedias)
                .HasForeignKey(m => m.MessageId);

            ChatMessageMedia.HasOne(ma => ma.MediaAsset).WithMany()
                        .HasForeignKey(ma => ma.MediaAssetId);

        }
    }
}
