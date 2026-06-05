using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Dto.User;

namespace SLMS.Application.Features.Users.Commands
{
    public class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest, UserDto>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public UpdateUserRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _mapper.Map<ApplicationCore.Domain.User.User>(request.User);
                var result = _unitOfWork.UserRepository.Update(user);
                await _unitOfWork.CommitAsync();
                return _mapper.Map<UserDto>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
