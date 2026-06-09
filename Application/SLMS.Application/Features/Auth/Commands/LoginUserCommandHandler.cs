using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Identity;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;

namespace SLMS.Application.Features.Auth.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public LoginCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByUserNameOrEmailAsync(request.UserNameOrEmail, cancellationToken);
            if (user == null)
            {
                throw new UnauthorizedException("نام کاربری یا گذرواژه اشتباه است");
            }
            bool passwordValid = _passwordHasher.VerifyPassword(request.Password, user.PasswordHash);
            if (!passwordValid)
            {
                throw new UnauthorizedException("نام کاربری یا گذرواژه اشتباه است.");
            }
            var response = _mapper.Map<LoginResponse>(user);
            var token =_jwtTokenGenerator.GenerateToken(user);
           
            response.Token = token;

            return response;
        }
    }
}
