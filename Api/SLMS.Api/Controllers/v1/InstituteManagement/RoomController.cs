using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SLMS.Application.Features.InstituteManagement.Room.Commands;
using SLMS.Application.Features.InstituteManagement.Room.Queries;
using SLMS.Dto.InstituteManagement;
using SLMS.Shared;

namespace SLMS.Api.Controllers.v1.InstituteManagement
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;
        public RoomController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedResult<RoomQueryResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1,
    [FromQuery] int pageSize = 10,
    [FromQuery] string? searchTerm = null)
        {
            var query = new GetRoomListRequest()
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                SearchTerm = searchTerm
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }
       
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomQueryResponse>> Get(Guid id)
        {
            var result = await _mediator.Send(new GetRoomRequest { Id = id });
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateRoomDto room)
        {
            var command = _mapper.Map<CreateRoomCommand>(room);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody]UpdateRoomDto room)
        {
            var command = _mapper.Map<UpdateRoomCommand>(room);
            command.Id = id;
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id,[FromBody] DeleteRoomDto room)
        {
            var command = _mapper.Map<DeleteRoomCommand>(room);
            command.Id = id;
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
