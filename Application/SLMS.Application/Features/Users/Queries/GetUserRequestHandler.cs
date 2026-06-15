using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;
using SLMS.ApplicationCore.Domain.User;
using SLMS.Dto.User;

namespace SLMS.Application.Features.Users.Queries
{
    public class GetUserRequestHandler : IRequestHandler<GetUserRequest, UserDto>
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
            var user = await _unitofwork.UserRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
                throw new NotFoundException(nameof(User), request.Id);

            return _mapper.Map<UserDto>(user);
        }
    }
}
