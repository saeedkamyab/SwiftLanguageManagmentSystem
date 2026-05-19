using MediatR;
using Microsoft.AspNetCore.Mvc;
using SLMS.Application.Features.SocialNetwork.Comments.Queries;
using SLMS.Application.Features.SocialNetwork.Comments.Commands;
using SLMS.Dto.SocialNetwork.Comments;

namespace SLMS.Api.Controllers.v1.SocialNetwork
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList(Guid postId)
        {
            var result = await _mediator.Send(new GetCommentListRequest() { PostId=postId});
            return Ok(result);
        }

        //[HttpGet("Recycling-bin")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetRecyclingbinList()
        //{
        //    var result = await _mediator.Send(new GetCommentRecyclingbinListRequest());
        //    return Ok(result);
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<CommentDto>> Get(Guid id)
        //{
        //    var result = await _mediator.Send(new GetCommentRequest { Id = id });
        //    return result;
        //}

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCommentDto Comment)
        {
            var command = new CreateCommentRequest { Comment = Comment };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        //[HttpPut]
        //public async Task<ActionResult> Update([FromBody] UpdateCommentDto Comment)
        //{
        //    var command = new UpdateCommentRequest { Comment = Comment };
        //    var response = await _mediator.Send(command);
        //    return Ok(response);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(Guid id)
        //{
        //    var command = new DeleteCommentRequest { Id = id };
        //    var response = await _mediator.Send(command);
        //    return Ok(response);
        //}
    }
}
