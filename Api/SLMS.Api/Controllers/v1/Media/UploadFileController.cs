using MediatR;
using Microsoft.AspNetCore.Mvc;
using SLMS.Application.Features.Media.Commands;
using SLMS.Dto.Media;
using SLMS.Shared.Enums;

namespace SLMS.Api.Controllers.v1.Media
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        protected readonly IMediator _mediator;

        public UploadFileController(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _mediator = mediator;
        }


        [HttpPost("upload")]
        [RequestSizeLimit(500 * 1024 * 1024)]
        [RequestFormLimits(MultipartBodyLengthLimit = 500 * 1024 * 1024)]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0) return BadRequest("فایل خالی است");

            string baseUploadDir = _configuration["FileStorage:UploadFolder"] ?? @"C:\SlmsUploads";
            var now = DateTime.Now;

            string datePath = Path.Combine(
       now.Year.ToString(),
       now.Month.ToString("00"),
       now.Day.ToString("00"));

            string fullDirectoryPath = Path.Combine(baseUploadDir, datePath);

            if (!Directory.Exists(fullDirectoryPath))
            {
                Directory.CreateDirectory(fullDirectoryPath);
            }

            string extension = Path.GetExtension(file.FileName);
            string storedName = Guid.NewGuid().ToString() + extension;
            string filePath = Path.Combine(fullDirectoryPath, storedName);


            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }


            string fileUrl = $"/cdn/{datePath.Replace("\\", "/")}/{storedName}";

            var media = new MediaAssetDto
            {
                FileName = file.FileName,
                StoredName = storedName,
                FileUrl = fileUrl,
                ContentType = file.ContentType,

                Extension = extension,
                IsDeleted = false,
                FileSize = file.Length,
                MetaData = "",
                MediaType = MediaType.Unknown,
                
            };

            var command = new CreateMediaAssetRequest { Media = media };
            var response = await _mediator.Send(command);


            return Ok(media); // برگرداندن آبجکت فایل
        }


    }
}
