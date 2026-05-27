using SLMS.ApplicationCore.Domain.Media;
using SLMS.Shared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.Messaging
{
    [Table("ChatMessageMedia", Schema = "Messaging")]
    public class ChatMessageMedia:BaseEntity
    {
        public Guid MessageId { get; set; }
        public virtual Message Message { get; set; }
        public Guid MediaAssetId { get; set; }
        public virtual MediaAsset MediaAsset { get; set; }
    }
}
