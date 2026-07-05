using Microsoft.EntityFrameworkCore;
using SLMS.Application.Contracts.Identity;
using SLMS.ApplicationCore;
using SLMS.ApplicationCore.Domain.InstituteManagement;
using SLMS.ApplicationCore.Domain.Media;
using SLMS.ApplicationCore.Domain.Messaging;
using SLMS.ApplicationCore.Domain.SocialNetwork;
using SLMS.ApplicationCore.Domain.User;

namespace SLMS.Persistence
{
    public class SLMSDbContext : DbContext
    {
        private readonly ICurrentUserService _currentUserService;
        public SLMSDbContext()
        {
        
        }
        public SLMSDbContext(DbContextOptions<SLMSDbContext> options, 
            ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        #region InstituteManagement
        public DbSet<AbsentPresent> AbsentPresents { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Institute> Institutes { get; set; }
        public DbSet<InstituteMembership> InstituteMemberships { get; set; }
        public DbSet<InstituteMembershipRole> InstituteMembershipRoles { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<MembershipRequest> MembershipRequests { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<TermCourse> TermCourses { get; set; }
        public DbSet<TermCourseSessionDay> TermCourseSessionDays { get; set; }
        #endregion

        #region SocialNetwork
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<ConversationMember> ConversationMembers { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostMedia> PostMedias { get; set; }
        public DbSet<ChatMessageMedia> ChatMessageMedias { get; set; }

        #endregion

        #region Media
        public DbSet<MediaAsset> MediaAsset { get; set; }

        #endregion


        #region Identity
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
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
                    entry.Entity.IsDeleted = false;
                    entry.Entity.CreateDate = DateTime.UtcNow;
                    if (_currentUserService.Id.HasValue)
                        entry.Entity.CreatedById = _currentUserService.Id.Value;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.LastUpdate = DateTime.UtcNow;
                    entry.Entity.LastUpdatedById = _currentUserService.Id;
                }
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SLMSDbContext).Assembly);
        }
    }
}
