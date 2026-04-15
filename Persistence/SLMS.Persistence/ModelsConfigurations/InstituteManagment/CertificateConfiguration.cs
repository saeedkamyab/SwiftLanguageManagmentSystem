using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Persistence.ModelsConfigurations.UserManagment
{
    public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> certificate)
        {
 
            certificate.HasOne(c => c.Classification)
                .WithOne(cl => cl.Certificate)
                .HasForeignKey<Certificate>(c => c.ClassificationId)
;

        }
    }
}
