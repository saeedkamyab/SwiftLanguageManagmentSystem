using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SLMS.Application.Features.InstituteManagement.AbsentPresent.Commands;
using SLMS.Application.Features.InstituteManagement.AbsentPresent.Queries;
using SLMS.Dto.InstituteManagement;
using SLMS.Shared;

namespace SLMS.Api.Controllers.v1.InstituteManagement
{
    [Authorize]
    [Route("api/absent-presents")]
    [ApiController]
    public class AbsentPresentController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;

        public AbsentPresentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedResult<AbsentPresentQueryResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] Guid? classifictionId = null,
            [FromQuery] bool? isPresent = null,
            CancellationToken cancellationToken = default)
        {
            var query = new GetAbsentPresentsQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                ClassifictionId = classifictionId,
                IsPresent = isPresent
            };

            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AbsentPresentQueryResponse>> Get(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAbsentPresentByIdQuery { Id = id }, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateAbsentPresentDto absentPresent, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateAbsentPresentCommand>(absentPresent);
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateAbsentPresentDto absentPresent, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateAbsentPresentCommand>(absentPresent);
            command.Id = id;
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id, [FromBody] DeleteAbsentPresentDto absentPresent, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<DeleteAbsentPresentCommand>(absentPresent);
            command.Id = id;
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }
    }
}
