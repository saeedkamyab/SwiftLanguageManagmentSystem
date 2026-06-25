using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Persistence.ModelsConfigurations.InstituteManagment
{
    public class TermCourseSessionDayConfiguration : IEntityTypeConfiguration<TermCourseSessionDay>
    {
        public void Configure(EntityTypeBuilder<TermCourseSessionDay> termCourseSessionDay)
        {

            termCourseSessionDay.HasOne(tcs => tcs.TermCourse)
                .WithMany(tc=>tc.TermCourseSessionDays)
                .HasForeignKey(tcs => tcs.TermCourseId);

        }
    }
}
