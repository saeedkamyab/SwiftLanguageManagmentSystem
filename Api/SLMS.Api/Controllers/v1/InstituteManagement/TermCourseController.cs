using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SLMS.Application.Features.InstituteManagement.TermCourse.Commands;
using SLMS.Application.Features.InstituteManagement.TermCourse.Queries;
using SLMS.Dto.InstituteManagement;
using SLMS.Shared;

namespace SLMS.Api.Controllers.v1.InstituteManagement
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TermCourseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;
        public TermCourseController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedResult<TermCourseQueryResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1,
    [FromQuery] int pageSize = 10,
    [FromQuery] string? searchTerm = null)
        {
            var query = new GetTermCourseListRequest()
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                SearchTerm = searchTerm
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }
       
        [HttpGet("{id}")]
        public async Task<ActionResult<TermCourseQueryResponse>> Get(Guid id)
        {
            var result = await _mediator.Send(new GetTermCourseRequest { Id = id });
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateTermCourseDto level)
        {
            var command = _mapper.Map<CreateTermCourseCommand>(level);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody]UpdateTermCourseDto level)
        {
            var command = _mapper.Map<UpdateTermCourseCommand>(level);
            command.Id = id;
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteTermCourseCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
