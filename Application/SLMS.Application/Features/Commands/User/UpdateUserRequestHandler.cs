using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Features.Commands.User.Requests;

namespace SLMS.Application.Features.Commands.User
{
    public class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest, bool>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public UpdateUserRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var User = _mapper.Map<ApplicationCore.Domain.User.User>(request.User);
                _unitOfWork.UserRepository.Update(User);
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
