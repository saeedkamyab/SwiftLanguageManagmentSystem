using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Persistence.ModelsConfigurations.InstituteManagment
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> category)
        {
            category.Property(i => i.Title)
                .HasMaxLength(150).IsRequired(true);

            category.HasMany(c => c.Fields)
                .WithOne(f => f.Category)
                .HasForeignKey(f => f.CategoryId);
        }
    }
}
