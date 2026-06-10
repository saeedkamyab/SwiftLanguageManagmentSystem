using AutoMapper;
using SLMS.Application.Features.Auth.Commands;
using SLMS.ApplicationCore.Domain.Media;
using SLMS.ApplicationCore.Domain.SocialNetwork;
using SLMS.ApplicationCore.Domain.User;
using SLMS.Dto.Media;
using SLMS.Dto.SocialNetwork;
using SLMS.Dto.SocialNetwork.Comments;
using SLMS.Dto.SocialNetwork.Post;
using SLMS.Dto.User;

namespace SLMS.Application
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region  UserManagment
            CreateMap<RegisterRequestDto, RegisterUserCommand>();
            CreateMap<User, RegisterUserResponse>();
            CreateMap<RegisterUserCommand, User>();
            CreateMap<User,Features.Auth.Commands.LoginResponse>();
            CreateMap<LoginRequestDto,LoginCommand>();

            CreateMap<UserDto,User>().ReverseMap();

            #endregion

            #region  SocialNetwork
            CreateMap<CreatePostDto, Post>();
            CreateMap<CreatePostMediaDto, PostMedia>();
            CreateMap<CreateCommentDto, Comment>();
            
            
            CreateMap<Post, PostSummaryDto>()
                .ForMember(postSummary => postSummary.OwnerId, opt => opt.MapFrom(post => post.PostOwner.Id))
                .ForMember(postSummary => postSummary.OwnerFirstName, opt => opt.MapFrom(post => post.PostOwner.FirstName))
                .ForMember(postSummary => postSummary.OwnerLastName, opt => opt.MapFrom(post => post.PostOwner.LastName))
                .ForMember(postSummary => postSummary.LikesCount, opt => opt.MapFrom(post => post.Likes.Count))
                .ForMember(postSummary => postSummary.BookmarksCount, opt => opt.MapFrom(post => post.Bookmarks.Count))
                .ForMember(postSummary => postSummary.OwnerAvatarUrl, opt => opt.MapFrom(post => post.PostOwner.ProfileImageUrl))
                .ForMember(postSummary => postSummary.CommentsCount, opt => opt.MapFrom(post => post.Comments.Count(c => !c.IsDeleted)))
                .ForMember(postSummary => postSummary.IsLikedByCurrentUser, opt => opt.Ignore())
                .ForMember(postSummary => postSummary.IsBookmarkedByCurrentUser, opt => opt.Ignore())
                .ForMember(postSummary => postSummary.IsCommentsLoaded, opt => opt.Ignore())
                .ForMember(postSummary => postSummary.Comments, opt => opt.Ignore())
                .ForMember(postSummary => postSummary.PostMedia, opt => opt.MapFrom(post => post.PostMedia));


            CreateMap<PostMedia, PostMediaDto>()
      .ForMember(d => d.MediaAsset, o => o.MapFrom(s => s.MediaAsset));

            CreateMap<PostMediaDto, PostMedia>();
            CreateMap<Comment, CommentDto>();

            #endregion


            #region  Media
            CreateMap<MediaAsset, MediaAssetDto>().ReverseMap();
            CreateMap<CreateMediaAssetDto, MediaAsset>();

            #endregion
        }
    }
}
