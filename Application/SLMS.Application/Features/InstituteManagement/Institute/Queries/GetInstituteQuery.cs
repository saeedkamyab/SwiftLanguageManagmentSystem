using MediatR;

namespace SLMS.Application.Features.InstituteManagement.Institute.Queries
{
    public class GetInstituteQuery:IRequest<InstituteQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
