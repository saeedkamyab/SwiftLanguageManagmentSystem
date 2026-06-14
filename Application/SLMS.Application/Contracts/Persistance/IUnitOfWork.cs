using SLMS.Application.Contracts.Identity;
using SLMS.Application.Contracts.SocialNetwork;
using SLMS.ApplicationCore.Domain.InstituteManagement;
using SLMS.ApplicationCore.Domain.Media;
using SLMS.ApplicationCore.Domain.Messaging;
using SLMS.ApplicationCore.Domain.SocialNetwork;

namespace SLMS.Application.Contracts.Persistance
{
    public interface IUnitOfWork
    {
        #region UserManagement
        IUserRepository UserRepository { get; }
        IBaseRepository<Comment> CommentRepository { get; }
        IBaseRepository<Conversation> ConversationRepository { get;  }
        IBaseRepository<ConversationMember> ConversationMemberRepository { get; }
        IBaseRepository<Follow> FollowRepository { get; }
        IBaseRepository<Message> MessageRepository { get; }
        IBaseRepository<PostMedia> PostMediaRepository { get; }
        ILikeRepository LikeRepository { get; }
        IPostRepository PostRepository { get;  }
        IBookmarkRepository BookmarkRepository { get;  }

        #endregion

        #region Media
        IBaseRepository<MediaAsset> MediaAssetRepository { get; }
        #endregion


        #region InstituteManagement
        IBaseRepository<AbsentPresent> AbsentPresentRepository { get; }
        IBaseRepository<Certificate> CertificateRepository { get; }
        IBaseRepository<Classification> ClassificationRepository { get;}
        IBaseRepository<Institute> InstituteRepository { get;  }
        IBaseRepository<InstituteMembership> InstituteMembershipRepository { get;  }
        IBaseRepository<Level> LevelRepository { get; }
        IBaseRepository<MembershipRequest> MembershipRequestRepository { get;  }
        IBaseRepository<Room> RoomRepository { get; }
        IBaseRepository<TermCourse> TermCourseRepository { get; }
        #endregion
      
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
