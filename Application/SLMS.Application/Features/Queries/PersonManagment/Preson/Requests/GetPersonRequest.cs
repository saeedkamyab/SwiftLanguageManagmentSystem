using MediatR;
using SLMS.Dto.PersonManagment;

namespace SLMS.Application.Features.Queries.PersonManagment.Preson.Requests
{
    public class GetPersonRequest:IRequest<PersonDto>
    {
        public Guid Id { get; set; }
    }
}
