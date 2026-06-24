using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;

namespace SLMS.Application.Features.InstituteManagement.Level.Queries
{
    public class GetLevelRequestHandler : IRequestHandler<GetLevelRequest, LevelQueryResponse>
    {
        IMapper _mapper;
        IUnitOfWork _unitofwork;

        public GetLevelRequestHandler(IMapper mapper, IUnitOfWork unitofwork)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
        }

        public async Task<LevelQueryResponse> Handle(GetLevelRequest request, CancellationToken cancellationToken)
        {
            var level = await _unitofwork.LevelRepository.GetByIdAsync(request.Id, cancellationToken);
            if (level == null)
                throw new NotFoundException(nameof(Level), request.Id);

            return _mapper.Map<LevelQueryResponse>(level);
        }
    }
}
