using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SLMS.Application.Features.InstituteManagement.Institute.Commands;
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
       
      
    //    [HttpGet]
    //    [ProducesResponseType(typeof(PagedResult<GetPostListQueryResponse>), StatusCodes.Status200OK)]
    //    public async Task<ActionResult<PagedResult<GetPostListQueryResponse>>> GetHomePagePosts(
    //[FromQuery] int pageNumber = 1,
    //[FromQuery] int pageSize = 10,
    //[FromQuery] bool onlyMyFollowings = false,
    //[FromQuery] string? searchTerm = null)
    //    {
    //        var query = new GetPostListQuery()
    //        {
    //            PageNumber = pageNumber,
    //            PageSize = pageSize,
    //            OnlyMyFollowings = onlyMyFollowings,
    //            SearchTerm = searchTerm
    //        };

    //        var result = await _mediator.Send(query);
    //        return Ok(result);
    //    }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateInstitudeDto institute)
        {
            var command = _mapper.Map<CreateInstituteCommand>(institute);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        //[HttpPut]
        //public async Task<ActionResult> Update([FromBody] UpdatePostDto post)
        //{
        //    var command = _mapper.Map<UpdatePostCommand>(post);
        //    var response = await _mediator.Send(command);
        //    return Ok(response);
        //}





    }
}
