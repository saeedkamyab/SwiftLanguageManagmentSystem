using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Persistence.ModelsConfigurations.InstituteManagment
{
    public class InstituteConfiguration : IEntityTypeConfiguration<Institute>
    {
        public void Configure(EntityTypeBuilder<Institute> institute)
        {
            institute.Property(i => i.Title).HasMaxLength(100).IsRequired(true);
            institute.Property(i => i.Description).HasMaxLength(300).IsRequired(false);
           
            institute.HasMany(i => i.InstituteFields)
                        .WithOne(i => i.Institute)
                        .HasForeignKey(i => i.InstituteId);

        }
    }
}
