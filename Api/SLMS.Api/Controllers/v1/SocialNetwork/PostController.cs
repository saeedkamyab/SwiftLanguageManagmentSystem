using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SLMS.Application.Features.SocialNetwork.Posts.Commands;

//using SLMS.Application.Features.Commands.SocialNetwork.Requests;
using SLMS.Application.Features.SocialNetwork.Posts.Queries;
using SLMS.Dto.SocialNetwork;

namespace SLMS.Api.Controllers.v1.SocialNetwork
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedResult<PostSummaryDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHomePagePosts(
    [FromQuery] int pageNumber = 1,
    [FromQuery] int pageSize = 10,
    [FromQuery] bool? onlyMyFollowings = null,
    [FromQuery] string? searchTerm = null)
        {
            //var currentUserId = User.GetUserId(); // Extension Method

            var query = new GetPostListRequest()
            {
                //CurrentUserId = currentUserId,
                PageNumber = pageNumber,
                PageSize = pageSize,
                //OnlyMyFollowings = onlyMyFollowings,
                SearchTerm = searchTerm
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<PostDto>> Get(Guid id)
        //{
        //    var result = await _mediator.Send(new GetPostRequest { Id = id });
        //    return result;
        //}

        [HttpPost("/api/v1/Post/{postId}/toggle-like")]
        public async Task<IActionResult> ToggleLike(Guid postId)
        {
            var userid = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            var res = await _mediator.Send(new ToggleLikeCommandRequest { PostId=postId,UserId=userid});
            return Ok(res);
        }

        
        
        
        
        
        //[HttpGet("Recycling-bin")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetRecyclingbinList()
        //{
        //    var result = await _mediator.Send(new GetPostRecyclingbinListRequest());
        //    return Ok(result);
        //}

        //[HttpPost]
        //public async Task<ActionResult> Create([FromBody] CreatePostDto Post)
        //{
        //    var command = new CreatePostRequest { Post = Post };
        //    var response = await _mediator.Send(command);
        //    return Ok(response);
        //}

        //[HttpPut]
        //public async Task<ActionResult> Update([FromBody] UpdatePostDto Post)
        //{
        //    var command = new UpdatePostRequest { Post = Post };
        //    var response = await _mediator.Send(command);
        //    return Ok(response);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(Guid id)
        //{
        //    var command = new DeletePostRequest { Id = id };
        //    var response = await _mediator.Send(command);
        //    return Ok(response);
        //}
    }
}
