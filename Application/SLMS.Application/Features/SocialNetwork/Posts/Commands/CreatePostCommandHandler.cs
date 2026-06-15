using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Identity;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;
using SLMS.ApplicationCore.Domain.SocialNetwork;

namespace SLMS.Application.Features.SocialNetwork.Posts.Commands
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, PostCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUser;
        public CreatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUser)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task<PostCommandResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {

            request.PostOwnerId = _currentUser.Id ?? throw new UnauthorizedAccessException();

            var Post = _mapper.Map<Post>(request);
            
            var result = await _unitOfWork.PostRepository.AddAsync(Post, cancellationToken);

            if (request.MediaAssetId.HasValue)
            {
                var mediaAsset = await _unitOfWork.MediaAssetRepository
                      .GetByIdAsync(request.MediaAssetId.Value,cancellationToken);

                if (mediaAsset is null)
                    throw new NotFoundException("MediaAsset not found", request.MediaAssetId.Value);

                mediaAsset.IsAttached = true;

                var postMedia = new PostMedia
                {
                    PostId = Post.Id,
                    MediaAssetId = mediaAsset.Id
                };

                await _unitOfWork.PostMediaRepository
 .AddAsync(postMedia, cancellationToken);


                _unitOfWork.MediaAssetRepository.Update(mediaAsset);
            }
            await _unitOfWork.CommitAsync();

            return _mapper.Map<PostCommandResponse>(result);

        }
    }
}
