using MediatR;
using SLMS.Dto.PersonManagement;

namespace SLMS.Application.Features.Commands.PersonManagement.Person.Requests
{
    public class UpdatePersonRequest : IRequest<bool>
    {
        public required PersonDto Person { get; set; }
    }
}
