using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SLMS.Application.Features.InstituteManagement.Membership.Commands;
using SLMS.Application.Features.InstituteManagement.Room.Commands;
using SLMS.ApplicationCore.Domain.InstituteManagement;
using SLMS.Dto.InstituteManagement;

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


        [HttpPost("{id}/active")]
        public async Task<ActionResult> ActiveMembership(Guid id, [FromBody] ActiveMembershipDto activeMembershipDto)
        {
            var command = _mapper.Map<ActiveMembershipCommand>(activeMembershipDto);
            command.Id= id;
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("{id}/deactive")]
        public async Task<ActionResult> DeactiveMembership(Guid id,[FromBody] DeactiveMembershipDto deactiveMembershipDto)
        {
            var command = _mapper.Map<DeactiveMembershipCommand>(deactiveMembershipDto);
            command.Id = id;
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
