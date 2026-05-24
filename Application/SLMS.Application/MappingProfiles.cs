using AutoMapper;
using SLMS.ApplicationCore.Domain.SocialNetwork;
using SLMS.ApplicationCore.Domain.User;
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
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, UserDto>().ReverseMap();
            #endregion

            #region  SocialNetwork
            //CreateMap<PostDto, Post>().ReverseMap();
            CreateMap<Post, PostSummaryDto>()
                .ForMember(postSummary => postSummary.OwnerId, opt => opt.MapFrom(post => post.PostOwner.Id))
                .ForMember(postSummary => postSummary.OwnerFirstName, opt => opt.MapFrom(post => post.PostOwner.FirstName))
                .ForMember(postSummary => postSummary.OwnerLastName, opt => opt.MapFrom(post => post.PostOwner.LastName))
                .ForMember(postSummary => postSummary.ImageUrl, opt => opt.MapFrom(post => post.ImageUrl))
                .ForMember(postSummary => postSummary.LikesCount, opt => opt.MapFrom(post => post.Likes.Count))
                .ForMember(postSummary => postSummary.BookmarksCount, opt => opt.MapFrom(post => post.Bookmarks.Count))
                .ForMember(postSummary => postSummary.OwnerAvatarUrl, opt => opt.MapFrom(post => post.PostOwner.ProfileImageUrl))
                //.ForMember(postSummary => postSummary.SharesCount, opt => opt.MapFrom(post => post.PostOwner.sh.Count))
                .ForMember(postSummary => postSummary.CommentsCount, opt => opt.MapFrom(post => post.Comments.Count(c => !c.IsDeleted)))
                .ForMember(postSummary => postSummary.IsLikedByCurrentUser, opt => opt.Ignore())
                .ForMember(postSummary => postSummary.IsBookmarkedByCurrentUser, opt => opt.Ignore())
                .ForMember(postSummary => postSummary.IsCommentsLoaded, opt => opt.Ignore())
                .ForMember(postSummary => postSummary.Comments, opt => opt.Ignore())
               /* .ForMember(postSummary => postSummary.OwnerFullName, opt => opt.Ignore())*/.ReverseMap()

                ;
            CreateMap<CreateCommentDto, Comment>();
            CreateMap<CommentDto, Comment>().ReverseMap();
            CreateMap<CreatePostDto, Post>().ReverseMap();
            #endregion
        }
    }
}
