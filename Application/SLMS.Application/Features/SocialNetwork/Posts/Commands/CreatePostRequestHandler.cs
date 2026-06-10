using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Identity;
using SLMS.Application.Contracts.Persistance;
using SLMS.ApplicationCore.Domain.Media;
using SLMS.Dto.SocialNetwork.Post;

namespace SLMS.Application.Features.SocialNetwork.Posts.Commands
{
    public class CreatePostRequestHandler : IRequestHandler<CreatePostRequest, PostDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUser;
        public CreatePostRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUser)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task<PostDto> Handle(CreatePostRequest request, CancellationToken cancellationToken)
        {
            try
            {
                MediaAsset mediaAsset = new();

                request.Post.PostOwnerId = _currentUser.Id;
                var Post = _mapper.Map<ApplicationCore.Domain.SocialNetwork.Post>(request.Post);
                var result = await _unitOfWork.PostRepository.AddAsync(Post, cancellationToken);

                if (request.Post.PostMedia != null)
                {
                    mediaAsset = await _unitOfWork.MediaAssetRepository.GetByIdAsync(request.Post.PostMedia.MediaAssetId);
                    mediaAsset.IsAttached = true;
                    Post.PostMedia.MediaAsset = mediaAsset;
                    _unitOfWork.MediaAssetRepository.Update(mediaAsset);
                }
                await _unitOfWork.CommitAsync();

                return _mapper.Map<PostDto>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
