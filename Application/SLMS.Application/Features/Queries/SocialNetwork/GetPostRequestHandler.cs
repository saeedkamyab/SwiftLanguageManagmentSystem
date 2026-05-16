using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Features.Queries.SocialNetwork.Requests;
using SLMS.Dto.SocialNetwork;

namespace SLMS.Application.Features.Queries.Post
{
    public class GetPostRequestHandler:IRequestHandler<GetPostRequest,PostDto>
    {
        IMapper _mapper;
        IUnitOfWork _unitofwork;

        public GetPostRequestHandler(IMapper mapper, IUnitOfWork unitofwork)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
        }

        public async Task<PostDto> Handle(GetPostRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var Post = await _unitofwork.PostRepository.GetByIdAsync(request.Id);
                return _mapper.Map<PostDto>(Post);
            }
            catch
            {
                throw;
            }
        }
    }
}
