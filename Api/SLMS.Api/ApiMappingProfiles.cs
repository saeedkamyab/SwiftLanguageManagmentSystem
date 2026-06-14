using AutoMapper;
using SLMS.Application.Features.Auth.Commands;
using SLMS.Application.Features.InstituteManagement.Institute.Commands;
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
            //----------------------User---------------------------------
            CreateMap<CreateInstitudeDto, CreateInstituteCommand>();

            #endregion
        }
    }
}
