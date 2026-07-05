using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;

namespace SLMS.Application.Features.InstituteManagement.Institute.Queries
{
    public class GetInstituteQueryHandler : IRequestHandler<GetInstituteQuery, InstituteQueryResponse>
    {
        IMapper _mapper;
        IUnitOfWork _unitofwork;

        public GetInstituteQueryHandler(IMapper mapper, IUnitOfWork unitofwork)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
        }

        public async Task<InstituteQueryResponse> Handle(GetInstituteQuery request, CancellationToken cancellationToken)
        {
            var institute = await _unitofwork.InstituteRepository.GetByIdAsync(request.Id, cancellationToken);
            if (institute == null)
                throw new NotFoundException(nameof(institute), request.Id);

            return _mapper.Map<InstituteQueryResponse>(institute);
        }
    }
}
