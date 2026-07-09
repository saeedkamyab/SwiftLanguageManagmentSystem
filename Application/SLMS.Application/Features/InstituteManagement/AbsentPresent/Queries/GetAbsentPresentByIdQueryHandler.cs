using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;

namespace SLMS.Application.Features.InstituteManagement.AbsentPresent.Queries
{
    public class GetAbsentPresentByIdQueryHandler : IRequestHandler<GetAbsentPresentByIdQuery, AbsentPresentQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAbsentPresentByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<AbsentPresentQueryResponse> Handle(GetAbsentPresentByIdQuery request, CancellationToken cancellationToken)
        {
            var absentPresent = await _unitOfWork.AbsentPresentRepository.GetByIdAsync(request.Id, cancellationToken);
            if (absentPresent == null)
                throw new NotFoundException(nameof(AbsentPresent), request.Id);

            return _mapper.Map<AbsentPresentQueryResponse>(absentPresent);
        }
    }
}
