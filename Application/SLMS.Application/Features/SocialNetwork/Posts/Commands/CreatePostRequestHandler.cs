using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;

namespace SLMS.Application.Features.SocialNetwork.Posts.Commands
{
    public class CreatePostRequestHandler : IRequestHandler<CreatePostRequest, bool>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public CreatePostRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreatePostRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var Post = _mapper.Map<ApplicationCore.Domain.SocialNetwork.Post>(request.Post);
                _unitOfWork.PostRepository.Add(Post);
                await _unitOfWork.CommitAsync();

                return true;
            }
            catch 
            {
                throw;
            }
        }
    }
}
