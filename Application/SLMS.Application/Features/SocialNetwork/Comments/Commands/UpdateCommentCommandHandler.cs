using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;

namespace SLMS.Application.Features.SocialNetwork.Comments.Commands
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, CommentCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommentCommandResponse> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            try
            {
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
