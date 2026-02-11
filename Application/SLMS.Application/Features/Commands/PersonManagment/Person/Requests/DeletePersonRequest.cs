using MediatR;
using SLMS.Dto.PersonManagment;

namespace SLMS.Application.Features.Commands.PersonManagment.Person.Requests
{
    public class DeletePersonRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
