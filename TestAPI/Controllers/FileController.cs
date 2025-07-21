using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Model;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost("upload"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFile([FromForm] FileUploadModel model)
        {
            if (model.file_url == null && model.file_url.Length == 0)
            {
                return BadRequest("Invalid File");
            }

            var folderName = Path.Combine("Uploads");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);
            }
            var fileName = model.file_url.FileName;

            //c://Resumes/filename.pdf
            var fullPath = Path.Combine(pathToSave, fileName);
            var dbPath = Path.Combine(folderName, fileName);

            if (System.IO.File.Exists(fullPath))
            {
                return BadRequest("File Already Exists");
            }
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                model.file_url.CopyTo(stream);
            }

            return Ok(new { dbPath });
        }
    }
}
