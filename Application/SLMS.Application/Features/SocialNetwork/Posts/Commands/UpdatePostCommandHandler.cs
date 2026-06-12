using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;

namespace SLMS.Application.Features.SocialNetwork.Posts.Commands
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, PostCommandResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public UpdatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PostCommandResponse> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
                var post = _mapper.Map<ApplicationCore.Domain.SocialNetwork.Post>(request);
                var result = _unitOfWork.PostRepository.Update(post);
                await _unitOfWork.CommitAsync();
                return _mapper.Map<PostCommandResponse>(result);
        }
    }
}
