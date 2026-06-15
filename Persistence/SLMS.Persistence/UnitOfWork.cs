using SLMS.Application.Contracts.Identity;
using SLMS.Application.Contracts.InstituteManagment;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Contracts.SocialNetwork;
using SLMS.ApplicationCore.Domain.InstituteManagement;
using SLMS.ApplicationCore.Domain.Media;
using SLMS.ApplicationCore.Domain.Messaging;
using SLMS.ApplicationCore.Domain.SocialNetwork;
using SLMS.Persistence.Repositories.Common;
using SLMS.Persistence.Repositories.Identity;
using SLMS.Persistence.Repositories.InstituteManagment;
using SLMS.Persistence.Repositories.SocialNetwork;

namespace SLMS.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SLMSDbContext _context;
        private bool _disposed;
        #region Fields -----------------------------------------------------------
        #region UserManagement
        private readonly Lazy<IUserRepository> _UserRepository;
        private readonly Lazy<IBaseRepository<Comment>> _CommentRepository;
        private readonly Lazy<IBaseRepository<Conversation>> _ConversationRepository;
        private readonly Lazy<IBaseRepository<ConversationMember>> _ConversationMemberRepository;
        private readonly Lazy<IBaseRepository<Follow>> _FollowRepository;
        private readonly Lazy<IBaseRepository<Message>> _MessageRepository;
        private readonly Lazy<IBaseRepository<PostMedia>> _PostMediaRepository;
        //private readonly Lazy<IBaseRepository<Like>> _LikeRepository;
        private readonly Lazy<ILikeRepository> _LikeRepository;
        private readonly Lazy<IPostRepository> _PostRepository;
        private readonly Lazy<IBookmarkRepository> _BookmarkRepository;
        //private readonly Lazy<IBaseRepository<Post>> _PostRepository;
        #endregion


        #region Media
        private readonly Lazy<IBaseRepository<MediaAsset>> _MediaAssetRepository;

        #endregion

        #region InstituteManagement
        private readonly Lazy<IBaseRepository<AbsentPresent>> _AbsentPresentRepository;
        private readonly Lazy<IBaseRepository<Certificate>> _CertificateRepository;
        private readonly Lazy<IBaseRepository<Classification>> _ClassificationRepository;
        private readonly Lazy<IBaseRepository<Institute>> _InstituteRepository;
        private readonly Lazy<IBaseRepository<InstituteMembership>> _InstituteMembershipRepository;
        private readonly Lazy<IBaseRepository<Level>> _LevelRepository;
        private readonly Lazy<IMembershipRequestRepository> _MembershipRequestRepository;
        private readonly Lazy<IBaseRepository<Room>> _RoomRepository;
        private readonly Lazy<IBaseRepository<TermCourse>> _TermCourseRepository;
        private readonly Lazy<IBaseRepository<Category>> _CategoryRepository;
        private readonly Lazy<IBaseRepository<Field>> _FieldRepository;
        private readonly Lazy<IBaseRepository<InstituteField>> _InstituteFieldRepository;
        #endregion



        #endregion

        #region Properties -------------------------------------------------------

        #region UserManagement
        public IUserRepository UserRepository => _UserRepository.Value;
        public IBaseRepository<Comment> CommentRepository => _CommentRepository.Value;
        public IBaseRepository<Conversation> ConversationRepository => _ConversationRepository.Value;
        public IBaseRepository<ConversationMember> ConversationMemberRepository => _ConversationMemberRepository.Value;
        public IBaseRepository<Follow> FollowRepository => _FollowRepository.Value;
        public IBaseRepository<Message> MessageRepository => _MessageRepository.Value;
        public IBaseRepository<PostMedia> PostMediaRepository => _PostMediaRepository.Value;
        //public IBaseRepository<Like> LikeRepository => _LikeRepository.Value;
        public ILikeRepository LikeRepository => _LikeRepository.Value;
        public IPostRepository PostRepository => _PostRepository.Value;
        public IBookmarkRepository BookmarkRepository => _BookmarkRepository.Value;
        //public IBaseRepository<Post> PostRepository => _PostRepository.Value;
        #endregion


        #region Media
        public IBaseRepository<MediaAsset> MediaAssetRepository => _MediaAssetRepository.Value;

        #endregion

        #region InstituteManagement
        public IBaseRepository<AbsentPresent> AbsentPresentRepository => _AbsentPresentRepository.Value;
        public IBaseRepository<Certificate> CertificateRepository => _CertificateRepository.Value;
        public IBaseRepository<Classification> ClassificationRepository => _ClassificationRepository.Value;
        public IBaseRepository<Institute> InstituteRepository => _InstituteRepository.Value;
        public IBaseRepository<InstituteMembership> InstituteMembershipRepository => _InstituteMembershipRepository.Value;
        public IBaseRepository<Level> LevelRepository => _LevelRepository.Value;
        public IMembershipRequestRepository MembershipRequestRepository => _MembershipRequestRepository.Value;
        public IBaseRepository<Room> RoomRepository => _RoomRepository.Value;
        public IBaseRepository<TermCourse> TermCourseRepository => _TermCourseRepository.Value;
        public IBaseRepository<Category> CategoryRepository => _CategoryRepository.Value;
        public IBaseRepository<Field> FieldRepository => _FieldRepository.Value;
        public IBaseRepository<InstituteField> InstituteFieldRepository => _InstituteFieldRepository.Value;

        #endregion




        #endregion

        public UnitOfWork(SLMSDbContext context)
        {
            _context = context;
            #region UserManagment
            _UserRepository = new Lazy<IUserRepository>(() => new UserRepository(_context));
            _CommentRepository = new Lazy<IBaseRepository<Comment>>(() => new BaseRepository<Comment>(_context));
            _ConversationRepository = new Lazy<IBaseRepository<Conversation>>(() => new BaseRepository<Conversation>(_context));
            _ConversationMemberRepository = new Lazy<IBaseRepository<ConversationMember>>(() => new BaseRepository<ConversationMember>(_context));
            _FollowRepository = new Lazy<IBaseRepository<Follow>>(() => new BaseRepository<Follow>(_context));
            _MessageRepository = new Lazy<IBaseRepository<Message>>(() => new BaseRepository<Message>(_context));
            _PostMediaRepository = new Lazy<IBaseRepository<PostMedia>>(() => new BaseRepository<PostMedia>(_context));
            //_LikeRepository = new Lazy<IBaseRepository<Like>>(() => new BaseRepository<Like>(_context));
            _LikeRepository = new Lazy<ILikeRepository>(() => new LikeRepository(_context));
            //_PostRepository = new Lazy<IBaseRepository<Post>>(() => new BaseRepository<Post>(_context));
            _PostRepository = new Lazy<IPostRepository>(() => new PostRepository(_context));
            _BookmarkRepository = new Lazy<IBookmarkRepository>(() => new BookmarkRepository(_context));
            #endregion

            #region UserManagment
            _MediaAssetRepository = new Lazy<IBaseRepository<MediaAsset>>(() => new BaseRepository<MediaAsset>(_context));
            #endregion



            #region InstituteManagment
            _AbsentPresentRepository = new Lazy<IBaseRepository<AbsentPresent>>(() => new BaseRepository<AbsentPresent>(_context));
            _CertificateRepository = new Lazy<IBaseRepository<Certificate>>(() => new BaseRepository<Certificate>(_context));
            _ClassificationRepository = new Lazy<IBaseRepository<Classification>>(() => new BaseRepository<Classification>(_context));
            _InstituteRepository = new Lazy<IBaseRepository<Institute>>(() => new BaseRepository<Institute>(_context));
            _InstituteMembershipRepository = new Lazy<IBaseRepository<InstituteMembership>>(() => new BaseRepository<InstituteMembership>(_context));
            _LevelRepository = new Lazy<IBaseRepository<Level>>(() => new BaseRepository<Level>(_context));
            _MembershipRequestRepository = new Lazy<IMembershipRequestRepository>(() => new MembershipRequestRepository(_context));
            _RoomRepository = new Lazy<IBaseRepository<Room>>(() => new BaseRepository<Room>(_context));
            _TermCourseRepository = new Lazy<IBaseRepository<TermCourse>>(() => new BaseRepository<TermCourse>(_context));
            _CategoryRepository = new Lazy<IBaseRepository<Category>>(() => new BaseRepository<Category>(_context));
            _FieldRepository = new Lazy<IBaseRepository<Field>>(() => new BaseRepository<Field>(_context));
            _InstituteFieldRepository = new Lazy<IBaseRepository<InstituteField>>(() => new BaseRepository<InstituteField>(_context));
            #endregion





        }
        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
        public void Dispose()
        {
            if (!_disposed)
            {
                _context.Dispose();
                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }

    }
}
