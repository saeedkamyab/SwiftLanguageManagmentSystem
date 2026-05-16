using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Features.Queries.SocialNetwork.Requests;
using SLMS.Dto.SocialNetwork;

namespace SLMS.Application.Features.Queries.SocialNetwork
{
    public class GetPostRecyclingbinListRequestHandler : IRequestHandler<GetPostRecyclingbinListRequest, List<PostDto>>
    {
        IMapper _mapper;
        IUnitOfWork _unitofwork;

        public GetPostRecyclingbinListRequestHandler(IMapper mapper, IUnitOfWork unitofwork)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
        }

        public async Task<List<PostDto>> Handle(GetPostRecyclingbinListRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var PostList = await _unitofwork.PostRepository.GetAllAsync(x=>x.IsDeleted==true);
                return _mapper.Map<List<PostDto>>(PostList);
            }
            catch
            {
                throw;
            }
        }
    }
}
