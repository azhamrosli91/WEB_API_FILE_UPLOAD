using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using TestAPI.Helper;

namespace TestAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class ResumeUploadController : ControllerBase
    {
        [HttpPost] //api/ResumeUpload/uploadfile
        public IActionResult UploadFile(IFormFile file_url)
        {
            return Ok(new UploadHandler().Upload(file_url));
        }
    }
}
