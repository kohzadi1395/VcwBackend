using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VcwBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostProfilePicture(List<IFormFile> file)
        {
            var stream = file[0].OpenReadStream();
            var name = file[0].FileName;

            return Ok();
        }
    }
}