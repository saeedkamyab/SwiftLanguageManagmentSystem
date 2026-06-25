using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;

namespace SLMS.Application.Features.InstituteManagement.TermCourse.Queries
{
    public class GetTermCourseRequestHandler : IRequestHandler<GetTermCourseRequest, TermCourseQueryResponse>
    {
        IMapper _mapper;
        IUnitOfWork _unitofwork;

        public GetTermCourseRequestHandler(IMapper mapper, IUnitOfWork unitofwork)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
        }

        public async Task<TermCourseQueryResponse> Handle(GetTermCourseRequest request, CancellationToken cancellationToken)
        {
            var termCourse = await _unitofwork.TermCourseRepository.GetByIdAsync(request.Id, cancellationToken);
            if (termCourse == null)
                throw new NotFoundException(nameof(TermCourse), request.Id);

            return _mapper.Map<TermCourseQueryResponse>(termCourse);
        }
    }
}
