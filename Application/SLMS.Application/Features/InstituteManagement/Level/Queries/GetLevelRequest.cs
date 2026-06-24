using MediatR;

namespace SLMS.Application.Features.InstituteManagement.Level.Queries
{
    public class GetLevelRequest:IRequest<LevelQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
