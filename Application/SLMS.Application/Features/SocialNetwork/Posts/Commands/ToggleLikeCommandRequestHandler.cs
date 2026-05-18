using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;

namespace SLMS.Application.Features.SocialNetwork.Posts.Commands
{
    public class ToggleLikeCommandRequestHandler : IRequestHandler<ToggleLikeCommandRequest, bool>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public ToggleLikeCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(ToggleLikeCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var userid = "3fa85f64-5717-4562-b3fc-2c963f66afa6";//مرجانه گلچین
              
                //var User = _mapper.Map<ApplicationCore.Domain.User.User>(request.User);
                //_unitOfWork.UserRepository.Add(User);
                //await _unitOfWork.CommitAsync();
                return true;
            }
            catch 
            {
                throw;
            }
        }
    }
}
