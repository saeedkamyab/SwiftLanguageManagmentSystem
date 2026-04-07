using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Features.Queries.UserManagement.Preson.Requests;
using SLMS.Dto.UserManagement;

namespace SLMS.Application.Features.Queries.UserManagement.Preson
{
    public class GetUserRequestHandler:IRequestHandler<GetUserRequest,UserDto>
    {
        IMapper _mapper;
        IUnitOfWork _unitofwork;

        public GetUserRequestHandler(IMapper mapper, IUnitOfWork unitofwork)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
        }

        public async Task<UserDto> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var User = await _unitofwork.UserRepository.GetByIdAsync(request.Id);
                return _mapper.Map<UserDto>(User);
            }
            catch
            {
                throw;
            }
        }
    }
}
