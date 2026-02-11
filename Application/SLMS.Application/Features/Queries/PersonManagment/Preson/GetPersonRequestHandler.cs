using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Features.Queries.PersonManagment.Preson.Requests;
using SLMS.Dto.PersonManagment;

namespace SLMS.Application.Features.Queries.PersonManagment.Preson
{
    public class GetPersonRequestHandler:IRequestHandler<GetPersonRequest,PersonDto>
    {
        IMapper _mapper;
        IUnitOfWork _unitofwork;

        public GetPersonRequestHandler(IMapper mapper, IUnitOfWork unitofwork)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
        }

        public async Task<PersonDto> Handle(GetPersonRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var person = await _unitofwork.PersonRepository.GetAsync(request.Id);
                return _mapper.Map<PersonDto>(person);
            }
            catch
            {
                throw;
            }
        }
    }
}
