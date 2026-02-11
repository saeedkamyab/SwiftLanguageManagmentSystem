using MediatR;
using SLMS.Dto.PersonManagement;

namespace SLMS.Application.Features.Queries.PersonManagement.Preson.Requests
{
    public class GetPersonListRequest:IRequest<List<PersonDto>>
    {
    }
}
