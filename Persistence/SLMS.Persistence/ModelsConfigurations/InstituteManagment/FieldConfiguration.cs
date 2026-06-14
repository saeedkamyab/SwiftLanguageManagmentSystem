using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Persistence.ModelsConfigurations.InstituteManagment
{
    public class FieldConfiguration : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> field)
        {
            field.Property(f => f.Title)
                .HasMaxLength(150).IsRequired(true);
           
            field.HasOne(f => f.Category)
                .WithMany(f => f.Fields)
                .HasForeignKey(f=>f.CategoryId);
        }
    }
}
