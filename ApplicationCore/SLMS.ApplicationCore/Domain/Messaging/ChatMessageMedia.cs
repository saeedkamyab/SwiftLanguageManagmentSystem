using SLMS.ApplicationCore.Domain.Media;
using SLMS.Shared.Enums;

namespace SLMS.ApplicationCore.Domain.Messaging
{
    public class ChatMessageMedia:BaseEntity
    {
        public Guid MessageId { get; set; }
        public virtual Message Message { get; set; }
        public Guid MediaAssetId { get; set; }
        public virtual MediaAsset MediaAsset { get; set; }
    }
}
