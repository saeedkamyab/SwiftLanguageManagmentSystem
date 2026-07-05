using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Persistence.ModelsConfigurations.InstituteManagment
{
    public class InstituteCategoryConfiguration : IEntityTypeConfiguration<InstituteCategory>
    {
        public void Configure(EntityTypeBuilder<InstituteCategory> instituteCategory)
        {
          
            instituteCategory.HasOne(x => x.Institute)
    .WithMany(x => x.InstituteCategories)
    .HasForeignKey(x => x.InstituteId);

            instituteCategory.HasOne(x => x.Category)
                .WithMany(x => x.InstituteCategories)
                .HasForeignKey(x => x.CategoryId);

        }
    }
}
