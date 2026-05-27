using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.SocialNetwork;

namespace SLMS.Persistence.ModelsConfigurations.SocialNetwork
{
    public class BookmarkConfiguration : BaseEntityConfiguration<Bookmark>
    {
        public override void Configure(EntityTypeBuilder<Bookmark> Bookmark)
        {
            Bookmark.HasOne(b => b.Post)
                .WithMany(p => p.Bookmarks)
                .HasForeignKey(l => l.PostId);
            Bookmark.HasOne(l => l.User)
                        .WithMany(u => u.Bookmarks)// you can have empty
                        .HasForeignKey(l => l.UserId);
        }
    }
}
