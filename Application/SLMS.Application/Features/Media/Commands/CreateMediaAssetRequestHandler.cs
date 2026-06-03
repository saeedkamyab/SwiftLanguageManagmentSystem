using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Dto.Media;

namespace SLMS.Application.Features.Media.Commands
{
    public class CreateMediaAssetRequestHandler : IRequestHandler<CreateMediaAssetRequest, MediaAssetDto>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public CreateMediaAssetRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MediaAssetDto> Handle(CreateMediaAssetRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var mediaAsset = _mapper.Map<ApplicationCore.Domain.Media.MediaAsset>(request.Media);
                var result = await _unitOfWork.MediaAssetRepository.AddAsync(mediaAsset, cancellationToken);
                await _unitOfWork.CommitAsync();
                return _mapper.Map<MediaAssetDto>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
