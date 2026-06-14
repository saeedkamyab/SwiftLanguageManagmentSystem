using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Persistence.ModelsConfigurations.InstituteManagment
{
    public class InstituteFieldConfiguration : IEntityTypeConfiguration<InstituteField>
    {
        public void Configure(EntityTypeBuilder<InstituteField> instituteField)
        {
          
            instituteField.HasOne(x => x.Institute)
    .WithMany(x => x.InstituteFields)
    .HasForeignKey(x => x.InstituteId);

            instituteField.HasOne(x => x.Field)
                .WithMany(x => x.InstituteFields)
                .HasForeignKey(x => x.FieldId);

        }
    }
}
