using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VcwBackend.DTOs;
using VcwBackend.Models;
using VcwBackend.Services;

namespace VcwBackend.Controllers
{
    [Route("api/Challenge")]
    [Produces("application/json")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly ChallengeRepository _challengeRepository;
        public ChallengeController()
        {
            _challengeRepository = new ChallengeRepository();
        }

//        [HttpPost]
//        public async Task<IActionResult> PostProfilePicture(List<IFormFile> file)
//        {
//            var stream = file[0].OpenReadStream();
//            var name = file[0].FileName;
//
//            return Ok();
//        }
//
//        [HttpPost]
//        public async Task<IActionResult> InsertChallenge([FromBody] Challenge challenge)
//        {
//           _challengeRepository.Insert(challenge);
//            return Ok();
//        }
        

        // GET api/values/5
        [HttpGet("{id}")]
        public Challenge Get(Guid id)
        {
            var challenge = _challengeRepository.GetChallenge(id);
            return challenge;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ChallengeUserPostDto challengeDto)
        {
            try
            {
                var invites = challengeDto.InvitePersonId.Select(x => new Invit
                {
                    Id = Guid.NewGuid(),
                    Deleted = false,
                    ChallengeId = challengeDto.Id,
                    UserId = x
                }).ToList();
                var challenge = new Challenge
                {
                    ChallengeType=challengeDto.ChallengeType,
                    CompanyName = challengeDto.CompanyName,
                    Deadline=  challengeDto.Deadline,
                    Description = challengeDto.Description,
                    FirstBounce = challengeDto.FirstBounce,
                    SecondBounce = challengeDto.SecondBounce,
                    ThirdBounce = challengeDto.ThirdBounce,
                    ChallengeState=challengeDto.ChallengeState,
                    Deleted =false,
                    Title = challengeDto.Title,
                    Id = challengeDto.Id,
                    CreateDate=DateTime.Now,
                    ModifDate = DateTime.Now,
                    Invites= invites

                };
                _challengeRepository.Insert(challenge);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _challengeRepository.Remove(id);
        }
//        [HttpGet]
//        public IEnumerable<ChallengeUserGetDto> Get()
//        {
//            var allChallenges = _challengeRepository.GetAllChallenges().Take(10);
//            return allChallenges;
//        }

        [HttpGet]
        public IEnumerable<ChallengeUserGetDto> GetAllChallenge()
        {
            var allChallenges = _challengeRepository.GetAllChallenges();
            return allChallenges;
        }
        [HttpPost("upload")]
        public ActionResult OnPostUpload(IFormFile file)
        {
//            if (files == null || files.Count <= 0)
//                return Content("Fail");
//            var folderName = "Upload";
//            var webRootPath = "";// _hostingEnvironment.WebRootPath;
//            var newPath = Path.Combine(webRootPath, folderName);
//            if (!Directory.Exists(newPath))
//            {
//                Directory.CreateDirectory(newPath);
//            }
//            foreach (var item in files)
//            {
//                if (item.Length > 0)
//                {
//                    var fileName = ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"');
//                    var fullPath = Path.Combine(newPath, fileName);
//                    using (var stream = new FileStream(fullPath, FileMode.Create))
//                    {
//                        item.CopyTo(stream);
//                    }
//                }
//            }
            return Content("Success");
        }
    }

}