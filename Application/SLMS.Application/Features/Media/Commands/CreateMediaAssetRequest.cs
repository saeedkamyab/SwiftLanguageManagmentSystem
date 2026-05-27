using MediatR;
using SLMS.Dto.Media;

namespace SLMS.Application.Features.Media.Commands
{
    public class CreateMediaAssetRequest : IRequest<bool>
    {
        public required MediaAssetDto Media { get; set; }
    }
}
