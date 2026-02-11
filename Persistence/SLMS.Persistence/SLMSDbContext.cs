using Microsoft.EntityFrameworkCore;
using SLMS.ApplicationCore;
using SLMS.ApplicationCore.Domain.PersonManagement;

namespace SLMS.Persistence
{
    public class SLMSDbContext : DbContext
    {
        public SLMSDbContext(DbContextOptions<SLMSDbContext> options) : base(options)
        {

        }

        #region PersonManagement
        public DbSet<Person> People { get; set; }

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
