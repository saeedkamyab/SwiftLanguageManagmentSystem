using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.ApplicationCore.Domain.SocialNetwork;

namespace SLMS.Application.Features.SocialNetwork.Posts.Commands
{
    public class ToggleBookmarkCommandRequestHandler : IRequestHandler<ToggleBookmarkCommandRequest, bool>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public ToggleBookmarkCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(ToggleBookmarkCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var userid = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");//مرجانه گلچین
                var post =await _unitOfWork.PostRepository.GetByIdAsync(request.PostId);
                var Bookmark =await _unitOfWork.BookmarkRepository.GetByUserAndPostAsync(request.PostId, userid);
                if (Bookmark == null)
                {
                     _unitOfWork.BookmarkRepository.Add(new Bookmark
                    {
                        PostId = request.PostId,
                        UserId = userid
                    });
                    post.BookmarksCount++;
                }
                else
                {
                    _unitOfWork.BookmarkRepository.Remove(Bookmark);
                    post.BookmarksCount--;
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
