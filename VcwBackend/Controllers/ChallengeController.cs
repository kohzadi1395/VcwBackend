using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces.Challenge;
using Application.Interfaces.General;
using Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VcwBackend.Controllers
{
    [Route("api/Challenge")]
    [Produces("application/json")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly IChallengeService _challengeService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _environment;

        public ChallengeController(IHostingEnvironment environment,
            IChallengeService challengeService, 
            IUnitOfWork unitOfWork)
        {
            _environment = environment;
            _challengeService = challengeService;
            _unitOfWork = unitOfWork;
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
            var challenge = _challengeService.GetChallenge(id);
            return challenge;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] ChallengeUserPostDto challengeDto)
        {
            try
            {
                var invites = challengeDto.InvitePersonId.Select(x => new Invite
                {
                    Id = Guid.NewGuid(),
                    Deleted = false,
                    ChallengeId = challengeDto.Id,
                    UserId = x
                }).ToList();
                var challenge = new Challenge
                {
                    ChallengeType = challengeDto.ChallengeType,
                    CompanyName = challengeDto.CompanyName,
                    Deadline = challengeDto.Deadline,
                    Description = challengeDto.Description,
                    FirstBounce = challengeDto.FirstBounce,
                    SecondBounce = challengeDto.SecondBounce,
                    ThirdBounce = challengeDto.ThirdBounce,
                    ChallengeState = challengeDto.ChallengeState,
                    Deleted = false,
                    Title = challengeDto.Title,
                    Id = challengeDto.Id,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    Invites = invites
                };
                _challengeService.AddChallenge(challenge);
                _unitOfWork.Commit();
                return Ok(challenge.Id);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
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

        public IActionResult Delete(Guid id)
        {
            try
            {
                _challengeService.RemoveChallenge(id);
                return Ok(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
//        [HttpGet]
//        public IEnumerable<ChallengeUserGetDto> Get()
//        {
//            var allChallenges = _challengeRepository.GetAllChallenges().Take(10);
//            return allChallenges;
//        }

        [HttpGet]
        public IActionResult GetAllChallenge()
        {
            try
            {
                var allChallenges = _challengeService.GetAllChallenges();
                return Ok(allChallenges);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SaveTicket(Challenge challenge)
        {
            //TODO: save the ticket ... get id

            var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsRootFolder))
            {
                Directory.CreateDirectory(uploadsRootFolder);
            }

            var files = Request.Form.Files;
            foreach (var file in files)
            {
                //TODO: do security checks ...!

                if (file == null || file.Length == 0)
                {
                    continue;
                }

                var filePath = Path.Combine(uploadsRootFolder, file.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream).ConfigureAwait(false);
                }
            }

            //return Created("", ticket);
            return Ok();
        }
    }
}