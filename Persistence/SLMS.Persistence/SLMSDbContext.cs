using Microsoft.EntityFrameworkCore;
using SLMS.ApplicationCore;
using SLMS.ApplicationCore.Domain.UserManagement;

namespace SLMS.Persistence
{
    public class SLMSDbContext : DbContext
    {
        public SLMSDbContext()
        {
            
        }
        public SLMSDbContext(DbContextOptions<SLMSDbContext> options) : base(options)
        {

        }

        #region UserManagement
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<ConversationMember> ConversationMembers { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Post> Post { get; set; }

        #endregion



        public override int SaveChanges()
        {
            SetCreateUpdateDate();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetCreateUpdateDate();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void SetCreateUpdateDate()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreateDate = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.LastUpdate = DateTime.UtcNow;
                }
            }
        }
    }
}
