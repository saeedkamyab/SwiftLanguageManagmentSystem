using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Application.Features.InstituteManagement.Level.Commands
{
    public class UpdateLevelCommandHandler : IRequestHandler<UpdateLevelCommand, LevelCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateLevelCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LevelCommandResponse> Handle(UpdateLevelCommand request, CancellationToken cancellationToken)
        {

            var level =await _unitOfWork.LevelRepository.GetByIdAsync(request.Id,cancellationToken);
            if (level == null)
                throw new NotFoundException(nameof(Level),request.Id);

            _mapper.Map(request, level);
            var result = _unitOfWork.LevelRepository.Update(level);
           
            await _unitOfWork.CommitAsync();
            return _mapper.Map<LevelCommandResponse>(result);

        }
    }
}
