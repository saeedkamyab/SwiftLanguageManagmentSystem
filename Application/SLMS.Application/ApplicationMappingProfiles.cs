using AutoMapper;
using SLMS.Application.Features.Auth.Commands;
using SLMS.Application.Features.SocialNetwork.Comments.Commands;
using SLMS.Application.Features.SocialNetwork.Posts.Commands;
using SLMS.Application.Features.SocialNetwork.Posts.Queries;
using SLMS.ApplicationCore.Domain.Media;
using SLMS.ApplicationCore.Domain.SocialNetwork;
using SLMS.ApplicationCore.Domain.User;
using SLMS.Dto.Media;
using SLMS.Dto.SocialNetwork;
using SLMS.Dto.SocialNetwork.Comments;

namespace SLMS.Application
{
    public class ApplicationMappingProfiles : Profile
    {
        public ApplicationMappingProfiles()
        {
            #region  UserManagment
            CreateMap<User, RegisterUserResponse>();
            CreateMap<RegisterUserCommand, User>();
            CreateMap<User,Features.Auth.Commands.LoginResponse>();


            #endregion

            #region  SocialNetwork

            //----------------------Comment---------------------------------
            CreateMap<Comment, CommentCommandResponse>();


            //----------------------Post---------------------------------
            CreateMap<Post, GetPostListQueryResponse>()
             .ForMember(postSummary => postSummary.OwnerId, opt => opt.MapFrom(post => post.PostOwner.Id))
             .ForMember(postSummary => postSummary.OwnerFirstName, opt => opt.MapFrom(post => post.PostOwner.FirstName))
             .ForMember(postSummary => postSummary.OwnerLastName, opt => opt.MapFrom(post => post.PostOwner.LastName))
             .ForMember(postSummary => postSummary.LikesCount, opt => opt.MapFrom(post => post.Likes.Count))
             .ForMember(postSummary => postSummary.BookmarksCount, opt => opt.MapFrom(post => post.Bookmarks.Count))
             .ForMember(postSummary => postSummary.OwnerAvatarUrl, opt => opt.MapFrom(post => post.PostOwner.ProfileImageUrl))
             .ForMember(postSummary => postSummary.CommentsCount, opt => opt.MapFrom(post => post.Comments.Count(c => !c.IsDeleted)))
             .ForMember(postSummary => postSummary.IsLikedByCurrentUser, opt => opt.Ignore())
             .ForMember(postSummary => postSummary.IsBookmarkedByCurrentUser, opt => opt.Ignore());

            CreateMap<CreatePostCommand, Post>();
            CreateMap<UpdatePostCommand, Post>();
            CreateMap<Post, PostCommandResponse>();





            CreateMap<CreateCommentCommand, Comment>();
            
            
         
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
