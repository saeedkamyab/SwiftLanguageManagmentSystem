using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;

namespace SLMS.Application.Features.InstituteManagement.AbsentPresent.Commands
{
    public class CreateAbsentPresentCommandHandler : IRequestHandler<CreateAbsentPresentCommand, AbsentPresentCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAbsentPresentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<AbsentPresentCommandResponse> Handle(
            CreateAbsentPresentCommand request,
            CancellationToken cancellationToken)
        {
            await AbsentPresentCommandGuards.EnsureClassificationBelongsToInstituteAsync(
                _unitOfWork,
                request.ClassifictionId,
                request.InstituteId,
                cancellationToken);

            var absentPresent = _mapper.Map<ApplicationCore.Domain.InstituteManagement.AbsentPresent>(request);
            var result = await _unitOfWork.AbsentPresentRepository.AddAsync(absentPresent, cancellationToken);

            await _unitOfWork.CommitAsync(cancellationToken);
            return _mapper.Map<AbsentPresentCommandResponse>(result);
        }
    }
}
