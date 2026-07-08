using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Persistence.ModelsConfigurations.InstituteManagment
{
    public class ClassificationConfiguration : IEntityTypeConfiguration<Classification>
    {
        public void Configure(EntityTypeBuilder<Classification> classification)
        {

            classification.Property(c => c.Title).HasMaxLength(100).IsRequired(true);

            classification.HasOne(c => c.TermCourse)
                .WithMany(tc => tc.Classifications)
                .HasForeignKey(c => c.TermCourseId)
;
            classification.HasOne(c => c.PupilMembership)
        .WithMany(im => im.Classifications)
        .HasForeignKey(c => c.PupilMembershipId)
;        }
    }
}
