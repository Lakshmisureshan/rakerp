using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class FileController : Controller
    {
        private readonly string _fileStoragePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");

        public FileController()
        {
            // Ensure the directory exists
            if (!Directory.Exists(_fileStoragePath))
            {
                Directory.CreateDirectory(_fileStoragePath);
            }
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var filePath = Path.Combine(_fileStoragePath, file.FileName);

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok(new { message = "File uploaded successfully!", filePath });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while uploading the file.");
            }
        }
    }
}

