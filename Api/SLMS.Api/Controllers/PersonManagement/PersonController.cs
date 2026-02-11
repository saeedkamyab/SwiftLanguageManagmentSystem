using MediatR;
using Microsoft.AspNetCore.Mvc;
using SLMS.Application.Features.Commands.PersonManagement.Person.Requests;
using SLMS.Application.Features.Queries.PersonManagement.Preson.Requests;
using SLMS.Dto.PersonManagement;

namespace SLMS.Api.Controllers.PersonManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetPersonListRequest());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> Get(Guid id)
        {
            var result = await _mediator.Send(new GetPersonRequest { Id = id });
            return result;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PersonDto person)
        {
            var command = new CreatePersonRequest { Person = person };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] PersonDto person)
        {
            var command = new UpdatePersonRequest { Person = person };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeletePersonRequest { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
