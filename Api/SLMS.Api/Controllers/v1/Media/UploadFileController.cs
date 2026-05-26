using Microsoft.AspNetCore.Mvc;
using SLMS.ApplicationCore.Domain.Media;

namespace SLMS.Api.Controllers.v1.Media
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        // تزریق آی‌کانفیگوریشن در سازنده
        public UploadFileController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0) return BadRequest("فایل خالی است");

        
            string extension = Path.GetExtension(file.FileName);
            string storedName = Guid.NewGuid().ToString() + extension;

       
            string uploadDir = _configuration["FileStorage:UploadFolder"] ?? @"C:\SlmsUploads";
            string filePath = Path.Combine(uploadDir, storedName);

         
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

         
            string fileUrl = $"/cdn/{storedName}";

         
            var media = new MediaAsset
            {
                FileName = file.FileName,
                StoredName = storedName,
                FileUrl = fileUrl,
                // ... بقیه مشخصات
            };
            //_context.MediaAssets.Add(media);
            //await _context.SaveChangesAsync();

            return Ok(media); // برگرداندن آبجکت فایل
        }


    }
}
