using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Identity;
using SLMS.Application.Contracts.Persistance;
using SLMS.ApplicationCore.Domain.SocialNetwork;

namespace SLMS.Application.Features.SocialNetwork.Posts.Commands
{
    public class ToggleBookmarkCommandRequestHandler : IRequestHandler<ToggleBookmarkCommandRequest, bool>
    {
       private readonly IUnitOfWork _unitOfWork;
       private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUser;
        public ToggleBookmarkCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper,ICurrentUserService currentUser)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(ToggleBookmarkCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var userid = _currentUser.Id ?? throw new UnauthorizedAccessException();
                var post =await _unitOfWork.PostRepository.GetByIdAsync(request.PostId);
                var Bookmark =await _unitOfWork.BookmarkRepository.GetByUserAndPostAsync(request.PostId, userid);
                if (Bookmark == null)
                {
                   var result=  _unitOfWork.BookmarkRepository.AddAsync(new Bookmark
                    {
                        PostId = request.PostId,
                        UserId = userid
                    },cancellationToken);
                    post.BookmarksCount++;
                }
                else
                {
                    _unitOfWork.BookmarkRepository.HardDelete(Bookmark);
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
