using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.SocialNetwork;

namespace SLMS.Persistence.ModelsConfigurations.SocialNetwork
{
    public class PostMediaConfiguration : BaseEntityConfiguration<PostMedia>
    {
        public override void Configure(EntityTypeBuilder<PostMedia> PostMedia)
        {
            PostMedia.HasOne(ma => ma.MediaAsset).WithMany()
                        .HasForeignKey(ma => ma.MediaAssetId);

        }
    }
}
