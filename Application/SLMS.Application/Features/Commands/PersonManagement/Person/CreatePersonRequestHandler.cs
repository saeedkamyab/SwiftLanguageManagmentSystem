using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Features.Commands.PersonManagement.Person.Requests;

namespace SLMS.Application.Features.Commands.PersonManagement.Person
{
    public class CreatePersonRequestHandler : IRequestHandler<CreatePersonRequest, bool>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public CreatePersonRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var person = _mapper.Map<ApplicationCore.Domain.PersonManagement.Person>(request.Person);
                _unitOfWork.PersonRepository.Add(person);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch 
            {
                throw;
            }
        }
    }
}
