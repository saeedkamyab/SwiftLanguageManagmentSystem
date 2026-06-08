using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SLMS.Application.Features.Auth.Commands;
using SLMS.Dto.User;

namespace SLMS.Api.Controllers.v1.Identity
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public AuthController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerUser)
        {
            var command = _mapper.Map<RegisterUserCommand>(registerUser);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
