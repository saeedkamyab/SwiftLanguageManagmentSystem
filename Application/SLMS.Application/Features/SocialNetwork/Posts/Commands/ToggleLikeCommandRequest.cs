using MediatR;
using SLMS.Dto.SocialNetwork;


namespace SLMS.Application.Features.SocialNetwork.Posts.Commands
{
    public class ToggleLikeCommandRequest : IRequest<bool>
    {
        public required Guid PostId { get; set; }
        public required Guid UserId { get; set; }

        //public required LikeDto Like{ get; set; }
    }
}
