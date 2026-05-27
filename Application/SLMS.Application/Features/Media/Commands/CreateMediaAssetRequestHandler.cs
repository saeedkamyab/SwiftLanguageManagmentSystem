using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;

namespace SLMS.Application.Features.Media.Commands
{
    public class CreateMediaAssetRequestHandler : IRequestHandler<CreateMediaAssetRequest, bool>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public CreateMediaAssetRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateMediaAssetRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var MediaAsset = _mapper.Map<ApplicationCore.Domain.Media.MediaAsset>(request.Media);
                _unitOfWork.MediaAssetRepository.Add(MediaAsset);
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
