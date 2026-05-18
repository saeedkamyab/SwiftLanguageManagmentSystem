using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.ApplicationCore.Domain.SocialNetwork;

namespace SLMS.Application.Features.SocialNetwork.Posts.Commands
{
    public class ToggleLikeCommandRequestHandler : IRequestHandler<ToggleLikeCommandRequest, bool>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public ToggleLikeCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(ToggleLikeCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var userid = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");//مرجانه گلچین
                var post =await _unitOfWork.PostRepository.GetByIdAsync(request.PostId);
                var like =await _unitOfWork.LikeRepository.GetByUserAndPostAsync(request.PostId, userid);
                if (like == null)
                {
                     _unitOfWork.LikeRepository.Add(new Like
                    {
                        PostId = request.PostId,
                        UserId = userid
                    });
                    post.LikesCount++;
                }
                else
                {
                    _unitOfWork.LikeRepository.Remove(like);
                    post.LikesCount--;
                }
                await _unitOfWork.CommitAsync();
               
                //var User = _mapper.Map<ApplicationCore.Domain.User.User>(request.User);
                //_unitOfWork.UserRepository.Add(User);
                //await _unitOfWork.CommitAsync();
                return true;
            }
            catch 
            {
                throw;
            }
        }
    }
}
