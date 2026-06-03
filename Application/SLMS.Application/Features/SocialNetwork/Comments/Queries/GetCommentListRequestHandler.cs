using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Services;
using SLMS.Dto.SocialNetwork.Comments;

namespace SLMS.Application.Features.SocialNetwork.Comments.Queries
{
    public class GetCommentListRequestHandler : IRequestHandler<GetCommentListRequest,List<CommentDto>>
    {
        IMapper _mapper;
        IUnitOfWork _unitofwork;

        public GetCommentListRequestHandler(IMapper mapper, IUnitOfWork unitofwork)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
        }

        public async Task<List<CommentDto>> Handle(GetCommentListRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var comments =await _unitofwork.CommentRepository.ListAsync(
                    x => x.PostId == request.PostId && !x.IsDeleted,
                      cancellationToken,
                       include => include
                       .Include(x => x.User)
                       .OrderBy(x => x.CreateDate));

                var tree = CommentTreeBuilder.BuildTree(_mapper.Map<List<CommentDto>>(comments));
                return tree;
            }
            catch
            {
                throw;
            }
        }
    }
}
