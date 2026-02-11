using MediatR;
using SLMS.Dto.PersonManagement;

namespace SLMS.Application.Features.Commands.PersonManagement.Person.Requests
{
    public class DeletePersonRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
