using MediatR;

namespace SLMS.Application.Features.InstituteManagement.AbsentPresent.Queries
{
    public class GetAbsentPresentByIdQuery : IRequest<AbsentPresentQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
