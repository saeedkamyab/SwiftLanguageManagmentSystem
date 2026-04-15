using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Persistence.ModelsConfigurations.UserManagment
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> room)
        {
            room.Property(r => r.Title).HasMaxLength(100);
            room.Property(r => r.Description).HasMaxLength(250).IsRequired(false);

            room.HasOne(r => r.Institute)
                .WithMany(i => i.Rooms)
                .HasForeignKey(r => r.InstituteId)
;
        }
    }
}
