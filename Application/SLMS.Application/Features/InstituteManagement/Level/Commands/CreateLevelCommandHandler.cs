using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Identity;
using SLMS.Application.Contracts.Persistance;

namespace SLMS.Application.Features.InstituteManagement.Level.Commands
{
    public class CreateLevelCommandHandler : IRequestHandler<CreateLevelCommand, LevelCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUser;

        public CreateLevelCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ICurrentUserService currentUser)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<LevelCommandResponse> Handle(CreateLevelCommand request,
            CancellationToken cancellationToken)
        {
            var level = _mapper.Map<ApplicationCore.Domain.InstituteManagement.Level>(request);
            var result = await _unitOfWork.LevelRepository.AddAsync(level, cancellationToken);

            await _unitOfWork.CommitAsync();
            return _mapper.Map<LevelCommandResponse>(result);

        }
    }
}
