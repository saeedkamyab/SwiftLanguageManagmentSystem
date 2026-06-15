using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Identity;
using SLMS.Application.Contracts.Persistance;
using SLMS.ApplicationCore.Domain.SocialNetwork;

namespace SLMS.Application.Features.SocialNetwork.Posts.Commands
{
    public class ToggleLikeCommandHandler : IRequestHandler<ToggleLikeCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUser;
        public ToggleLikeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUser)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(ToggleLikeCommand request, CancellationToken cancellationToken)
        {

                var userid = _currentUser.Id ?? throw new UnauthorizedAccessException();
                var post =await _unitOfWork.PostRepository.GetByIdAsync(request.PostId, cancellationToken)??throw new Exceptions.NotFoundException();
                var like =await _unitOfWork.LikeRepository.GetByUserAndPostAsync(request.PostId, userid);
                if (like == null)
                {
                    var result= _unitOfWork.LikeRepository.AddAsync(new Like
                    {
                        PostId = request.PostId,
                        UserId = userid
                    },cancellationToken);
                    post.LikesCount++;
                }
                else
                {
                    _unitOfWork.LikeRepository.HardDelete(like);
                    post.LikesCount--;
                }
                await _unitOfWork.CommitAsync();
               
             
                return true;
          
        }
    }
}
