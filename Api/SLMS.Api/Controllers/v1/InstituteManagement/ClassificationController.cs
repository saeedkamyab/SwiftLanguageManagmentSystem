using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SLMS.Application.Features.InstituteManagement.Classification.Commands;
//using SLMS.Application.Features.InstituteManagement.Classification.Queries;
using SLMS.Dto.InstituteManagement;
using SLMS.Shared;

namespace SLMS.Api.Controllers.v1.InstituteManagement
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClassificationController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;
        public ClassificationController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

    //    [HttpGet]
    //    [ProducesResponseType(typeof(PagedResult<ClassificationQueryResponse>), StatusCodes.Status200OK)]
    //    public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1,
    //[FromQuery] int pageSize = 10,
    //[FromQuery] string? searchTerm = null)
    //    {
    //        var query = new GetClassificationListRequest()
    //        {
    //            PageNumber = pageNumber,
    //            PageSize = pageSize,
    //            SearchTerm = searchTerm
    //        };

    //        var result = await _mediator.Send(query);
    //        return Ok(result);
    //    }
       
    //    [HttpGet("{id}")]
    //    public async Task<ActionResult<ClassificationQueryResponse>> Get(Guid id)
    //    {
    //        var result = await _mediator.Send(new GetClassificationQuery { Id = id });
    //        return Ok(result);
    //    }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateClassificationDto classification)
        {
            var command = _mapper.Map<CreateClassificationCommand>(classification);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id, [FromBody] DeleteClassificationDto termCourse)
        {
            var command = _mapper.Map<DeleteClassificationCommand>(termCourse);
            command.Id = id;
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
