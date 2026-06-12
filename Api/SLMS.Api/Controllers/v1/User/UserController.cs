using MediatR;
using Microsoft.AspNetCore.Mvc;
using SLMS.Application.Features.Auth.Commands;
using SLMS.Application.Features.Users.Commands;
using SLMS.Application.Features.Users.Queries;
using SLMS.Dto;
using SLMS.Dto.User;
using SLMS.Shared;

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
        [ProducesResponseType(typeof(PagedResult<UserDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1,
    [FromQuery] int pageSize = 10,
    [FromQuery] string? searchTerm = null)
        {
            var query = new GetUserListRequest()
            {
                //CurrentUserId = currentUserId,
                PageNumber = pageNumber,
                PageSize = pageSize,
                SearchTerm = searchTerm
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("Recycling-bin")]
        [ProducesResponseType(typeof(PagedResult<UserDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRecyclingbinList([FromQuery] int pageNumber = 1,
    [FromQuery] int pageSize = 10,
    [FromQuery] string? searchTerm = null)
        {
            var query = new GetUserListRequest()
            {
                //CurrentUserId = currentUserId,
                PageNumber = pageNumber,
                PageSize = pageSize,
                SearchTerm = searchTerm
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(Guid id)
        {
            var result = await _mediator.Send(new GetUserRequest { Id = id });
            return Ok(result);
        }

        //[HttpPost]
        //public async Task<ActionResult> Create([FromBody] RegisterRequestDto user)
        //{
        //    var command = new RegisterUserCommand { RegisterRequest = user };
        //    var response = await _mediator.Send(command);
        //    return Ok(response);
        //}

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
