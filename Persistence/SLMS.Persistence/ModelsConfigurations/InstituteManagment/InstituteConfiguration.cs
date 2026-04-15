using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Persistence.ModelsConfigurations.UserManagment
{
    public class InstituteConfiguration : IEntityTypeConfiguration<Institute>
    {
        public void Configure(EntityTypeBuilder<Institute> institute)
        {

            institute.Property(i => i.Title).HasMaxLength(100);
            institute.Property(i => i.Title).HasMaxLength(300);
            institute.Property(i => i.Description).HasMaxLength(250).IsRequired(false);

        }
    }
}
