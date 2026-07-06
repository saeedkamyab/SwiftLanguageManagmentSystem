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


        //[HttpPost("{id}/active")]
        //public async Task<ActionResult> ActiveMembership(Guid id)
        //{
        //    var command = new ActiveMembershipCommand
        //    {
        //        Id = id
        //    };
        //    var response = await _mediator.Send(command);
        //    return Ok(response);
        //}
        //[HttpPost("{id}/deactive")]
        //public async Task<ActionResult> DeactiveMembership(Guid id)
        //{
        //    var command = new DeactiveMembershipCommand
        //    {
        //        Id = id
        //    };
        //    var response = await _mediator.Send(command);
        //    return Ok(response);
        //}

    }
}
