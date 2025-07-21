using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Services;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileManagerController : ControllerBase
    {
        private readonly IManageFile _iManageFile;
        public FileManagerController(IManageFile iManageFile)
        {
            _iManageFile = iManageFile;
        }

        [HttpPost]
        [Route("uploadfile")]
        public async Task<IActionResult> UploadFile(IFormFile _IformFile)
        {
            var result = await _iManageFile.UploadFile(_IformFile);
            return Ok(result);
        }
        [HttpGet]
        [Route("downloadfile")]
        public async Task<IActionResult> DownloadFile(string FileName)
        {
            var result = await _iManageFile.DownloadFile(FileName);
            return File(result.Item1, result.Item2, result.Item2);
        }
    }
}
