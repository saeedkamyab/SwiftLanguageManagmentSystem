using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Features.Queries.UserManagement.User.Requests;
using SLMS.Dto.UserManagement;

namespace SLMS.Application.Features.Queries.UserManagement.User
{
    public class GetUserListRequestHandler : IRequestHandler<GetUserListRequest,List<UserDto>>
    {
        IMapper _mapper;
        IUnitOfWork _unitofwork;

        public GetUserListRequestHandler(IMapper mapper, IUnitOfWork unitofwork)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
        }

        public async Task<List<UserDto>> Handle(GetUserListRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var UserList = await _unitofwork.UserRepository.GetAllAsync();
                return _mapper.Map<List<UserDto>>(UserList);
            }
            catch
            {
                throw;
            }
        }
    }
}
