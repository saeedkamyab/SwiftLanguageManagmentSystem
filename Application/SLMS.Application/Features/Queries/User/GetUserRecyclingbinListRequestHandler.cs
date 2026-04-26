using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Features.Queries.User.Requests;
using SLMS.Dto.User;

namespace SLMS.Application.Features.Queries.User
{
    public class GetUserRecyclingbinListRequestHandler : IRequestHandler<GetUserRecyclingbinListRequest, List<UserDto>>
    {
        IMapper _mapper;
        IUnitOfWork _unitofwork;

        public GetUserRecyclingbinListRequestHandler(IMapper mapper, IUnitOfWork unitofwork)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
        }

        public async Task<List<UserDto>> Handle(GetUserRecyclingbinListRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var UserList = await _unitofwork.UserRepository.GetAllAsync(x=>x.IsDeleted==true);
                return _mapper.Map<List<UserDto>>(UserList);
            }
            catch
            {
                throw;
            }
        }
    }
}
