using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;

namespace SLMS.Application.Features.Users.Commands
{
    public class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequest, bool>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public DeleteUserRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            try
            { 
                await _unitOfWork.UserRepository.SoftDelete(request.Id);
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
