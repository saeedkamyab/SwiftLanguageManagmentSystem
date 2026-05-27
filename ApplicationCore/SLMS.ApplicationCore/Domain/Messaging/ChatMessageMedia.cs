using SLMS.ApplicationCore.Domain.Media;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.Messaging
{
    [Table("ChatMessageMedia", Schema = "Messaging")]
    public class ChatMessageMedia:BaseEntity
    {
        public Guid MessageId { get; set; }
        public Message Message { get; set; } = null!;
        public Guid MediaAssetId { get; set; }
        public MediaAsset MediaAsset { get; set; } = null!;
    }
}
