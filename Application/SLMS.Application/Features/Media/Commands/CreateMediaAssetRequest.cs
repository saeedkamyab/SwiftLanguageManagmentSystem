using MediatR;
using SLMS.Dto.Media;

namespace SLMS.Application.Features.Media.Commands
{
    public class CreateMediaAssetRequest : IRequest<MediaAssetDto>
    {
        public required CreateMediaAssetDto Media { get; set; }
    }
}
