using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Identity;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;
using SLMS.ApplicationCore.Domain.User;

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
        .ExistsByUserNameAsync(request.UserName, cancellationToken);
            var emailExists =
    await _unitOfWork.UserRepository
        .ExistsByEmailAsync(request.Email, cancellationToken);

            if (userExists)
            {
                throw new ConflictException("نام کاربری تکراری است");
            }
            if (emailExists)
            {
                throw new ConflictException("ایمیل تکراری است");
            }

            await InsertOneMillionUsers(cancellationToken);

            //var user = _mapper.Map<ApplicationCore.Domain.User.User>(request);
            //user.PasswordHash = _passwordHasher.HashPassword(request.Password);
            //var result = await _unitOfWork.UserRepository.AddAsync(user, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            //return _mapper.Map<RegisterUserResponse>(result);
            return _mapper.Map<RegisterUserResponse>(new SLMS.ApplicationCore.Domain.User.User());
        }

        async Task InsertOneMillionUsers(CancellationToken cancellationToken)
        {
            const int batchSize = 1000; 
            const int totalRecords = 400000;
            var users = new List<User>(batchSize);

            for (int i = 0; i < totalRecords; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                users.Add(new User
                {
                    Id = Guid.NewGuid(),
                    UserName = $"uas{i}",
                    Email = $"uas{i}@gmail.com",
                    PasswordHash = _passwordHasher.HashPassword("12345678")
                });

                // وقتی به تعداد مشخص رسید، Bulk Insert کن
                if (users.Count >= batchSize || i == totalRecords - 1)
                {
                    await _unitOfWork.UserRepository.AddRangeAsync(users, cancellationToken);
                    await _unitOfWork.CommitAsync(cancellationToken);

                    users.Clear(); // آزادسازی حافظه
                    Console.WriteLine($"ثبت {i + 1} رکورد انجام شد");
                }
            }
        }

    }
}
