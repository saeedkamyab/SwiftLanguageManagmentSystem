using AutoMapper;
using SLMS.Application.Features.Auth.Commands;
using SLMS.Application.Features.InstituteManagement.Institute.Commands;
using SLMS.Application.Features.InstituteManagement.Level.Commands;
using SLMS.Application.Features.InstituteManagement.Membership.Commands;
using SLMS.Application.Features.InstituteManagement.MembershipRequest.Commands;
using SLMS.Application.Features.InstituteManagement.Room.Commands;
using SLMS.Application.Features.InstituteManagement.TermCourse.Commands;
using SLMS.Application.Features.SocialNetwork.Comments.Commands;
using SLMS.Application.Features.SocialNetwork.Posts.Commands;
using SLMS.Dto.InstituteManagement;
using SLMS.Dto.SocialNetwork.Comments;
using SLMS.Dto.SocialNetwork.Post;
using SLMS.Dto.User;

namespace SLMS.Api
{
    public class ApiMappingProfiles : Profile
    {
        public ApiMappingProfiles()
        {
            #region  UserManagment
            //----------------------User---------------------------------
            CreateMap<RegisterDto, RegisterUserCommand>();
            CreateMap<LoginDto,LoginCommand>();
          

            #endregion

            #region  SocialNetwork
            //----------------------Comment---------------------------------
            CreateMap<CreateCommentDto, CreateCommentCommand>();
            CreateMap<UpdateCommentDto, UpdateCommentCommand>();
           
            
            //----------------------Post---------------------------------
            CreateMap<CreatePostDto, CreatePostCommand>();
            CreateMap<UpdatePostDto, UpdatePostCommand>();



            #endregion

            #region  InstituteManagement
            //----------------------Instutite---------------------------------
            CreateMap<CreateInstituteDto, CreateInstituteCommand>();
            CreateMap<UpdateInstituteDto, UpdateInstituteCommand>();

            //----------------------Instutite Membership---------------------------------
            CreateMap<CreateMembershipRequestDto, CreateMembershipRequestCommand>();               
            CreateMap<ApproveMembershipRequestDto, ApproveMembershipRequestCommand>();
            
            CreateMap<ActiveMembershipDto, ActiveMembershipCommand>();
            CreateMap<DeactiveMembershipDto, DeactiveMembershipCommand>();




            //----------------------Level---------------------------------
            CreateMap<CreateLevelDto, CreateLevelCommand>();
            CreateMap<UpdateLevelDto, UpdateLevelCommand>();


            //----------------------Room---------------------------------
            CreateMap<CreateRoomDto, CreateRoomCommand>();
            CreateMap<UpdateRoomDto, UpdateRoomCommand>();


            //----------------------TermCourse---------------------------------
            CreateMap<CreateTermCourseDto, CreateTermCourseCommand>();
            CreateMap<UpdateTermCourseDto, UpdateTermCourseCommand>();

            #endregion
        }
    }
}
