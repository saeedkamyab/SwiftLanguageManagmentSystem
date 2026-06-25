using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;

namespace SLMS.Application.Features.InstituteManagement.TermCourse.Commands
{
    public class UpdateTermCourseCommandHandler : IRequestHandler<UpdateTermCourseCommand, TermCourseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateTermCourseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TermCourseCommandResponse> Handle(UpdateTermCourseCommand request, CancellationToken cancellationToken)
        {

            var termCourse =await _unitOfWork.TermCourseRepository.GetByIdAsync(request.Id,cancellationToken);
            if (termCourse == null)
                throw new NotFoundException(nameof(TermCourse),request.Id);

            _mapper.Map(request, termCourse);
            var result = _unitOfWork.TermCourseRepository.Update(termCourse);
           
            await _unitOfWork.CommitAsync();
            return _mapper.Map<TermCourseCommandResponse>(result);

        }
    }
}
