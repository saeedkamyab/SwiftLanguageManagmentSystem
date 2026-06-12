using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SLMS.Dto.Media;
using SLMS.Dto.SocialNetwork;
using SLMS.Dto.SocialNetwork.Post;
using SLMS.WebApplicationComponents.Services.Api.SocialNetwork.Interface;
using SLMS.WebApplicationComponents.Services.Base;
using SLMS.WebApplicationComponents.Services.Base.Interfaces;
using SLMS.WebApplicationComponents.Services.Upload;

namespace SLMS.WebApplicationComponents.Components.SocialNetwork.Post
{
    public partial class AddPostComponent
    {
        private bool isUploading;
        private int uploadProgress;
        private CreatePostDto Post { get; set; } = new();
        private MediaAssetDto uploadedMedia = new();
        [Inject] private IPostService PostService { get; set; } = null!;
        [Inject] private IMediaUrlResolver MediaUrl { get; set; } = null!;
        [Inject] private FeedStateService FeedState { get; set; } = null!;
        [Inject] private IMediaUploadClientService MediaUploadClientService { get; set; } = null!;



        private async Task HandleFileSelected(InputFileChangeEventArgs e)
        {
            isUploading = true;
            try
            {
                var res = await MediaUploadClientService.UploadFileAsync(e.File);
                if (res != null)
                {
                    uploadedMedia = res;
                }
            }
            finally
            {
                isUploading = false;
            }
        }
        private async Task CreatePost()
        {
            Post.MediaAssetId =  uploadedMedia.Id;
            var success = await PostService.CreatePost(Post);

            if (!success)
                return;

            await FeedState.NotifyPostAddedAsync();
            Post = new();
            uploadedMedia = new();

        }

    }
}