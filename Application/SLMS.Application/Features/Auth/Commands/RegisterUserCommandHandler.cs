using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Identity;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;

namespace SLMS.Application.Features.Auth.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
       
        public RegisterUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            
            var userExists =
    await _unitOfWork.UserRepository
        .ExistsByUserNameAsync(request.UserName);
            var emailExists =
    await _unitOfWork.UserRepository
        .ExistsByEmailAsync(request.Email);

            if (userExists)
            {
                throw new ConflictException("نام کاربری تکراری است");
            }
            if ( emailExists)
            {
                throw new ConflictException("ایمیل تکراری است");
            }
            var user = _mapper.Map<ApplicationCore.Domain.User.User>(request);
            user.PasswordHash = _passwordHasher.HashPassword(request.Password);
            var result = await _unitOfWork.UserRepository.AddAsync(user, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return _mapper.Map<RegisterUserResponse>(result);
        }
    }
}
