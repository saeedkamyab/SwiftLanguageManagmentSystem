using MediatR;
using Microsoft.AspNetCore.Mvc;
using SLMS.Application.Features.Users.Queries;
using SLMS.Application.Features.Users.Commands;
using SLMS.Dto.User;

namespace SLMS.Api.Controllers.v1.User
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetUserListRequest());
            return Ok(result);
        }
        [HttpGet("Recycling-bin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRecyclingbinList()
        {
            var result = await _mediator.Send(new GetUserRecyclingbinListRequest());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(Guid id)
        {
            var result = await _mediator.Send(new GetUserRequest { Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateUserDto user)
        {
            var command = new CreateUserRequest { User = user };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateUserDto user)
        {
            var command = new UpdateUserRequest { User = user };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteUserRequest { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
