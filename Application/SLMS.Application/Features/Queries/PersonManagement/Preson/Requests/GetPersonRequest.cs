using MediatR;
using SLMS.Dto.PersonManagement;

namespace SLMS.Application.Features.Queries.PersonManagement.Preson.Requests
{
    public class GetPersonRequest:IRequest<PersonDto>
    {
        public Guid Id { get; set; }
    }
}
