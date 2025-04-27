using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly string _fileStoragePath = Path.Combine(Directory.GetCurrentDirectory(), "JobLPO");
        private readonly string _PRStoragePath = Path.Combine(Directory.GetCurrentDirectory(), "PRFILE");
        public FileUploadController()
        {
            // Ensure the directory exists
            if (!Directory.Exists(_fileStoragePath))
            {
                Directory.CreateDirectory(_fileStoragePath);
            }
        }

        //[HttpPost("upload")]
        //public async Task<IActionResult> Upload([FromForm] IFormFile file, string jobid)
        //{
        //    if (file == null || file.Length == 0)
        //    {
        //        return BadRequest("No file uploaded.");
        //    }

        //    var filePath = Path.Combine(_fileStoragePath, jobid);

        //    try
        //    {
        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await file.CopyToAsync(stream);
        //        }

        //        return Ok(new { message = "File uploaded successfully!", filePath });
        //    }
        //    catch
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while uploading the file.");
        //    }
        //}
        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file, string jobid)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            // Check if the file is a PDF
            if (file.ContentType != "application/pdf")
            {
                return BadRequest("Only PDF files are allowed.");
            }

            // Validate file extension as additional security
            var extension = Path.GetExtension(file.FileName);
            if (string.IsNullOrEmpty(extension) || !extension.Equals(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Invalid file format. Only PDF files are allowed.");
            }

            // Create a directory for the job ID if it doesn't exist
            var jobFolderPath = Path.Combine(_fileStoragePath, jobid);
            if (!Directory.Exists(jobFolderPath))
            {
                Directory.CreateDirectory(jobFolderPath);
            }

            var filePath = Path.Combine(jobFolderPath, file.FileName);

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok(new { message = "File uploaded successfully!", filePath });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while uploading the file: {ex.Message}");
            }
        }



        [HttpPost("uploadpr")]
        public async Task<IActionResult> Uploadpr([FromForm] IFormFile file, string prid)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            // Check if the file is a PDF
            if (file.ContentType != "application/pdf")
            {
                return BadRequest("Only PDF files are allowed.");
            }

            // Validate file extension as additional security
            var extension = Path.GetExtension(file.FileName);
            if (string.IsNullOrEmpty(extension) || !extension.Equals(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Invalid file format. Only PDF files are allowed.");
            }

            // Create a directory for the job ID if it doesn't exist
            var prfolderpath = Path.Combine(_PRStoragePath, prid);
            if (!Directory.Exists(prfolderpath))
            {
                Directory.CreateDirectory(prfolderpath);
            }

            var filePath = Path.Combine(prfolderpath, file.FileName);

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok(new { message = "File uploaded successfully!", filePath });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while uploading the file: {ex.Message}");
            }
        }






















    }
}
