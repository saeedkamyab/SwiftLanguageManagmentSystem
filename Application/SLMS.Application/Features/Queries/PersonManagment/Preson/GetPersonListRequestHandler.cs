using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Features.Queries.PersonManagment.Preson.Requests;
using SLMS.Dto.PersonManagment;

namespace SLMS.Application.Features.Queries.PersonManagment.Preson
{
    public class GetPersonListRequestHandler : IRequestHandler<GetPersonListRequest,List<PersonDto>>
    {
        IMapper _mapper;
        IUnitOfWork _unitofwork;

        public GetPersonListRequestHandler(IMapper mapper, IUnitOfWork unitofwork)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
        }

        public async Task<List<PersonDto>> Handle(GetPersonListRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var personList = await _unitofwork.PersonRepository.GetListAsync();
                return _mapper.Map<List<PersonDto>>(personList);
            }
            catch
            {
                throw;
            }
        }
    }
}
