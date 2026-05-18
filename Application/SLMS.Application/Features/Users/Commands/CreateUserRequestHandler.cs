using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;

namespace SLMS.Application.Features.Users.Commands
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, bool>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public CreateUserRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var User = _mapper.Map<ApplicationCore.Domain.User.User>(request.User);
                _unitOfWork.UserRepository.Add(User);
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
