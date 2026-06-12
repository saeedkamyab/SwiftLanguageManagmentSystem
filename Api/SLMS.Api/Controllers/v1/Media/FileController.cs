using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SLMS.Application.Contracts.FileService;

namespace SLMS.Api.Controllers.v1.Media
{
    //[Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
    
        private readonly IMediaUploadService _mediaUploadService;
        
        public FileController(IMediaUploadService mediaUploadService /*,IConfiguration configuration,*/)
        {
            _mediaUploadService = mediaUploadService;
        }


        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        [RequestSizeLimit(500 * 1024 * 1024)]
        [RequestFormLimits(MultipartBodyLengthLimit = 500 * 1024 * 1024)]
        public async Task<IActionResult> Upload(IFormFile file, CancellationToken cancellationToken)
        {
            var result = await _mediaUploadService.UploadAsync(file, cancellationToken);
            return Ok(result);
        }


    }
}
