using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;

namespace SLMS.Application.Features.SocialNetwork.Comments.Commands
{
    public class CreateCommentRequestHandler : IRequestHandler<CreateCommentRequest, bool>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public CreateCommentRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var Comment = _mapper.Map<ApplicationCore.Domain.SocialNetwork.Comment>(request.Comment);
                _unitOfWork.CommentRepository.Add(Comment);
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
