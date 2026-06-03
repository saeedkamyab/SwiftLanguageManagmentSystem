using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Dto.User;

namespace SLMS.Application.Features.Users.Commands
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, UserDto>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public CreateUserRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var User = _mapper.Map<ApplicationCore.Domain.User.User>(request.User);
               var result= _unitOfWork.UserRepository.AddAsync(User,cancellationToken);
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
