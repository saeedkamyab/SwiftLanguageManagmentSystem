using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Persistence.ModelsConfigurations.InstituteManagment
{
    public class LevelConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> level)
        {

            level.Property(l => l.Title).HasMaxLength(100).IsRequired(true);

            level.HasOne(l => l.Institute)
                .WithMany(c => c.Levels)
                .HasForeignKey(l => l.InstituteId)
;        }
    }
}
