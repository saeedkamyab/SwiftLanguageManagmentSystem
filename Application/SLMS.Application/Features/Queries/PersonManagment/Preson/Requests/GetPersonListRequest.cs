using MediatR;
using SLMS.Dto.PersonManagment;

namespace SLMS.Application.Features.Queries.PersonManagment.Preson.Requests
{
    public class GetPersonListRequest:IRequest<List<PersonDto>>
    {
    }
}
