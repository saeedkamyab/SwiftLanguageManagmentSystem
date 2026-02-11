using MediatR;
using SLMS.Dto.PersonManagment;

namespace SLMS.Application.Features.Commands.PersonManagment.Person.Requests
{
    public class CreatePersonRequest : IRequest<bool>
    {
        public required PersonDto Person { get; set; }
    }
}
