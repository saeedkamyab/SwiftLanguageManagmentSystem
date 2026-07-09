using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;

namespace SLMS.Application.Features.InstituteManagement.AbsentPresent.Commands
{
    public class UpdateAbsentPresentCommandHandler : IRequestHandler<UpdateAbsentPresentCommand, AbsentPresentCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAbsentPresentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<AbsentPresentCommandResponse> Handle(UpdateAbsentPresentCommand request, CancellationToken cancellationToken)
        {
            await AbsentPresentCommandGuards.EnsureAbsentPresentBelongsToInstituteAsync(
                _unitOfWork,
                request.Id,
                request.InstituteId,
                cancellationToken);

            await AbsentPresentCommandGuards.EnsureClassificationBelongsToInstituteAsync(
                _unitOfWork,
                request.ClassifictionId,
                request.InstituteId,
                cancellationToken);

            var absentPresent = await _unitOfWork.AbsentPresentRepository.GetByIdAsync(request.Id, cancellationToken);
            if (absentPresent == null)
                throw new NotFoundException("AbsentPresent was not found.");

            _mapper.Map(request, absentPresent);
            var result = _unitOfWork.AbsentPresentRepository.Update(absentPresent);

            await _unitOfWork.CommitAsync(cancellationToken);
            return _mapper.Map<AbsentPresentCommandResponse>(result);
        }
    }
}
