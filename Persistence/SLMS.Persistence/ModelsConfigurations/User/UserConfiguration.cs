using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SLMS.Persistence.ModelsConfigurations.User
{
    public class UserConfiguration : BaseEntityConfiguration<ApplicationCore.Domain.User.User>
    {
        public override void Configure(EntityTypeBuilder<ApplicationCore.Domain.User.User> user)
        {
            user.Property(u => u.UserName).HasMaxLength(250).IsRequired(true);
            user.Property(u => u.PasswordHash).HasMaxLength(1500).IsRequired(true);
            user.Property(u => u.Email).HasMaxLength(250).IsRequired(true);


            user.Property(u => u.PhoneNumber).HasMaxLength(11).IsRequired(false);
            user.Property(u => u.FirstName).HasMaxLength(100).IsRequired(false);
            user.Property(u => u.LastName).HasMaxLength(100).IsRequired(false);
            user.Property(u => u.FatherName).HasMaxLength(100).IsRequired(false);
            user.Property(u => u.NationalCode).HasMaxLength(10).IsFixedLength().IsRequired(false);

            user.HasIndex(u => u.UserName).IsUnique();
            user.HasIndex(x => x.Email).IsUnique();
        }
    }
}
