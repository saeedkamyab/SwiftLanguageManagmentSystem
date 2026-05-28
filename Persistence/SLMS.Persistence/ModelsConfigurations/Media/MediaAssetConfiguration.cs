using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.Media;

namespace SLMS.Persistence.ModelsConfigurations.Media
{
    public class MediaAssetConfiguration : BaseEntityConfiguration<MediaAsset>
    {
        public override void Configure(EntityTypeBuilder<MediaAsset> MediaAsset)
        {
            MediaAsset.Property(ma => ma.FileName).IsRequired(true);
            MediaAsset.Property(ma => ma.StoredName).IsRequired(true);
            MediaAsset.Property(ma => ma.FileUrl).IsRequired(true);
            MediaAsset.Property(ma => ma.Extension).IsRequired(true);
            MediaAsset.Property(ma => ma.FileSize).IsRequired(true);
            MediaAsset.Property(ma => ma.ContentType).IsRequired(true);
            MediaAsset.Property(ma => ma.MetaData).IsRequired(false);
        }
    }
}
