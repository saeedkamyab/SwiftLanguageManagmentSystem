using AutoMapper;
using SLMS.Application.Features.Auth.Commands;
using SLMS.Application.Features.InstituteManagement.Institute.Commands;
using SLMS.Application.Features.InstituteManagement.Level.Commands;
using SLMS.Application.Features.InstituteManagement.Level.Queries;
using SLMS.Application.Features.InstituteManagement.MembershipRequest.Commands;
using SLMS.Application.Features.InstituteManagement.Room.Commands;
using SLMS.Application.Features.InstituteManagement.Room.Queries;
using SLMS.Application.Features.InstituteManagement.TermCourse.Commands;
using SLMS.Application.Features.InstituteManagement.TermCourse.Queries;
using SLMS.Application.Features.SocialNetwork.Comments.Commands;
using SLMS.Application.Features.SocialNetwork.Posts.Commands;
using SLMS.Application.Features.SocialNetwork.Posts.Queries;
using SLMS.ApplicationCore.Domain.InstituteManagement;
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


            //----------------------PostMedia---------------------------------
            CreateMap<PostMedia, PostMediaDto>()
      .ForMember(d => d.MediaAsset, o => o.MapFrom(s => s.MediaAsset));
            CreateMap<PostMediaDto, PostMedia>();


            //----------------------Post Command---------------------------------
            CreateMap<CreatePostCommand, Post>();
            CreateMap<UpdatePostCommand, Post>();
            CreateMap<Post, PostCommandResponse>();





            //----------------------Command---------------------------------
            CreateMap<CreateCommentCommand, Comment>();  
            CreateMap<Comment, CommentDto>();

            #endregion


            #region  Media
            CreateMap<MediaAsset, MediaAssetDto>().ReverseMap();
            CreateMap<CreateMediaAssetDto, MediaAsset>();

            #endregion

            #region  Institute Managment

            //---------------Institute----------------------------
            CreateMap<CreateInstituteCommand, Institute>();
            CreateMap<Institute, InstituteCommandResponse>();


            //---------------Institute Membership----------------------------
            CreateMap<CreateMembershipRequestCommand, MembershipRequest>();
            CreateMap<MembershipRequest, MembershipRequestCommandResponse>();
            CreateMap<InstituteMembership, MembershipRequestCommandResponse>();
           
            

            //---------------Level----------------------------
            CreateMap<Level, LevelQueryResponse>();
            CreateMap<CreateLevelCommand, Level>();
            CreateMap<UpdateLevelCommand, Level>();
            CreateMap<Level, LevelCommandResponse>();


            //---------------Room----------------------------
            CreateMap<Room, RoomQueryResponse>();
            CreateMap<CreateRoomCommand, Room>();
            CreateMap<UpdateRoomCommand, Room>();
            CreateMap<Room, RoomCommandResponse>();

            //---------------TermCourse----------------------------
            CreateMap<TermCourse, TermCourseQueryResponse>();
            CreateMap<CreateTermCourseCommand, TermCourse>();
            CreateMap<UpdateTermCourseCommand, TermCourse>()
    .ForMember(x => x.Id, opt => opt.Ignore())
    .ForMember(x => x.TermCourseSessionDays, opt => opt.Ignore());
            CreateMap<TermCourse, TermCourseCommandResponse>();


            #endregion


        }
    }
}
