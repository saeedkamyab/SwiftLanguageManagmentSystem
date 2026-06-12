using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Identity;
using SLMS.Application.Contracts.Persistance;

namespace SLMS.Application.Features.SocialNetwork.Comments.Commands
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CommentCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUser;
        public CreateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUser = currentUserService;
        }

        public async Task<CommentCommandResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.UserId = _currentUser.Id ?? throw new UnauthorizedAccessException();
                var Comment = _mapper.Map<ApplicationCore.Domain.SocialNetwork.Comment>(request);
                var result = await _unitOfWork.CommentRepository.AddAsync(Comment, cancellationToken);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<CommentCommandResponse>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
