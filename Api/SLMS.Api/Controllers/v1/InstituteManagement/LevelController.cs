using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SLMS.Application.Features.InstituteManagement.Level.Commands;
using SLMS.Application.Features.InstituteManagement.Level.Queries;
using SLMS.Dto.InstituteManagement;
using SLMS.Shared;

namespace SLMS.Api.Controllers.v1.InstituteManagement
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;
        public LevelController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedResult<LevelQueryResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1,
    [FromQuery] int pageSize = 10,
    [FromQuery] string? searchTerm = null)
        {
            var query = new GetLevelListRequest()
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                SearchTerm = searchTerm
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }
       
        [HttpGet("{id}")]
        public async Task<ActionResult<LevelQueryResponse>> Get(Guid id)
        {
            var result = await _mediator.Send(new GetLevelRequest { Id = id });
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateLevelDto level)
        {
            var command = _mapper.Map<CreateLevelCommand>(level);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody]UpdateLevelDto level)
        {
            var command = _mapper.Map<UpdateLevelCommand>(level);
            command.Id = id;
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id, [FromBody] DeleteLevelDto level)
        {
            var command = _mapper.Map<DeleteLevelCommand>(level);
            command.Id = id;
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
