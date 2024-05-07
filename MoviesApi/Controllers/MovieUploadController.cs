using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace MoviesApi.Controllers
{
    [Route("api/uploadmovie")]
    [ApiController]
    public class MovieUploadController : ControllerBase
    {


        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)] 

        public ActionResult UploadMovie()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("ImagenesPost");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = Guid.NewGuid() + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName + "/", fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(dbPath);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal Server Error{ex}");
            }
        }
    }
}
