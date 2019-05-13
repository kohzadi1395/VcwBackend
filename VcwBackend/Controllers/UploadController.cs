using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace VcwBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IHostingEnvironment _environment;

        public UploadController(IHostingEnvironment environment)
        {
            _environment = environment;
        }
    }
}