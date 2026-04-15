using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Persistence.ModelsConfigurations.UserManagment
{
    public class AbsentPresentConfiguration : IEntityTypeConfiguration<AbsentPresent>
    {
        public void Configure(EntityTypeBuilder<AbsentPresent> absentPresent)
        {

            absentPresent.Property(ap => ap.Description).HasMaxLength(250).IsRequired(false);

            absentPresent.HasOne(ap => ap.Classifiction)
                .WithMany(c => c.AbsentPresents)
                .HasForeignKey(ap => ap.ClassifictionId)
;        }
    }
}
