using MediatR;
using Microsoft.AspNetCore.Mvc;
using SLMS.Application.Features.Commands.UserManagement.User.Requests;
using SLMS.Application.Features.Queries.UserManagement.Preson.Requests;
using SLMS.Dto.UserManagement;

namespace SLMS.Api.Controllers.UserManagement
{
    [Route("api/[controller]")]
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
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(Guid id)
        {
            var result = await _mediator.Send(new GetUserRequest { Id = id });
            return result;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserDto User)
        {
            var command = new CreateUserRequest { User = User };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UserDto User)
        {
            var command = new UpdateUserRequest { User = User };
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
