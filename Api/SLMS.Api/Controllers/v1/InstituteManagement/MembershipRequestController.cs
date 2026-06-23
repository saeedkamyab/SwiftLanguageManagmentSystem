using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SLMS.Application.Features.InstituteManagement.MembershipRequest.Commands;
using SLMS.Dto.InstituteManagement;

namespace SLMS.Api.Controllers.v1.InstituteManagement
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MembershipRequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MembershipRequestController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateRequest([FromBody] CreateMembershipRequestDto membershipRequest)
        {
            var command = _mapper.Map<CreateMembershipRequestCommand>(membershipRequest);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("{id}/approve")]
        public async Task<ActionResult> ApproveRequest(Guid id, ApproveMembershipRequestDto approveMembership)
        {
            var command = new ApproveMembershipRequestCommand
            {
                Id=id,
                MemberType=approveMembership.MemberType,
            };
            var response= await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPost("{id}/reject")]
        public async Task<ActionResult> RejectRequest(Guid id)
        {
            var command = new RejectMembershipRequestCommand
            {
                Id = id
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
