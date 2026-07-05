using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SLMS.Api.Controllers.v1.InstituteManagement
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InstituteMembershipController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public InstituteMembershipController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        //[HttpGet("{id}")]
        //public async Task<ActionResult<InstituteMembershipQueryResponse>> Get(Guid id)
        //{
        //    var result = await _mediator.Send(new GetInstituteMembershipQuery { Id = id });
        //    return Ok(result);
        //}
       
        //[HttpPut("{id}")]
        //public async Task<ActionResult> Update(Guid id, [FromBody] UpdateInstituteMembershipDto institute)
        //{
        //    var command = _mapper.Map<UpdateInstituteMembershipCommand>(institute);
        //    command.Id = id;
        //    var response = await _mediator.Send(command);
        //    return Ok(response);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(Guid id)
        //{
        //    var command = new DeleteInstituteMembershipCommand { Id = id };
        //    var response = await _mediator.Send(command);
        //    return Ok(response);
        //}


    }
}
