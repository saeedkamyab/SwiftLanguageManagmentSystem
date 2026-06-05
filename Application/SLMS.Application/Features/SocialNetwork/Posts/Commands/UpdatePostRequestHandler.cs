using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;

namespace SLMS.Application.Features.SocialNetwork.Posts.Commands
{
    public class UpdatePostRequestHandler : IRequestHandler<UpdatePostRequest, bool>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public UpdatePostRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdatePostRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var post = _mapper.Map<ApplicationCore.Domain.SocialNetwork.Post>(request.Post);
                _unitOfWork.PostRepository.Update(post);
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
