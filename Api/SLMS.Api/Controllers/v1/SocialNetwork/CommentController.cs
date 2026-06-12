using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SLMS.Application.Features.SocialNetwork.Comments.Commands;
using SLMS.Application.Features.SocialNetwork.Comments.Queries;
using SLMS.Dto.SocialNetwork.Comments;

namespace SLMS.Api.Controllers.v1.SocialNetwork
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CommentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList(Guid postId)
        {
            var result = await _mediator.Send(new GetCommentListRequest() { PostId=postId});
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCommentDto Comment)
        {
            var command = _mapper.Map<CreateCommentCommand>(Comment);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateCommentDto Comment)
        {
            var command = _mapper.Map<UpdateCommentCommand>(Comment);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var response = await _mediator.Send(new DeleteCommentCommand { Id=id});
            return Ok(response);
        }
    }
}
