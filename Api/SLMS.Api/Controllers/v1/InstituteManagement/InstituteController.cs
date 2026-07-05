using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SLMS.Application.Features.InstituteManagement.Institute.Commands;
using SLMS.Application.Features.InstituteManagement.Institute.Queries;
using SLMS.Application.Features.InstituteManagement.Level.Queries;
using SLMS.Application.Features.InstituteManagement.Room.Commands;
using SLMS.Dto.InstituteManagement;

namespace SLMS.Api.Controllers.v1.InstituteManagement
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InstituteController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public InstituteController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<InstituteQueryResponse>> Get(Guid id)
        {
            var result = await _mediator.Send(new GetInstituteQuery { Id = id });
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateInstituteDto institute)
        {
            var command = _mapper.Map<CreateInstituteCommand>(institute);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

       
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateInstituteDto institute)
        {
            var command = _mapper.Map<UpdateInstituteCommand>(institute);
            command.Id = id;
            var response = await _mediator.Send(command);
            return Ok(response);
        }




    }
}
