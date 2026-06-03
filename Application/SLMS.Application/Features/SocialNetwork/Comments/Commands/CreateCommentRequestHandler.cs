using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Dto.SocialNetwork.Comments;

namespace SLMS.Application.Features.SocialNetwork.Comments.Commands
{
    public class CreateCommentRequestHandler : IRequestHandler<CreateCommentRequest, CommentDto>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public CreateCommentRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommentDto> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var Comment = _mapper.Map<ApplicationCore.Domain.SocialNetwork.Comment>(request.Comment);
               var result=await _unitOfWork.CommentRepository.AddAsync(Comment,cancellationToken);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<CommentDto>(result);
            }
            catch 
            {
                throw;
            }
        }
    }
}
