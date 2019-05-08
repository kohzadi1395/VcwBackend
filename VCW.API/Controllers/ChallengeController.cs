using System;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly ChallengeRepository _challengeRepository;

        public ChallengeController()
        {
            _challengeRepository = new ChallengeRepository();
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var user = _challengeRepository.GetChallenge(id);

            if (user == null)
                return NotFound("Challenge not found");

            return Ok(user);
        }

        [HttpGet]
        public ActionResult Get()
        {
            var users = _challengeRepository.GetAllChallenges();

            if (users == null)
                return NotFound("Challenge not found");

            return Ok(users);
        }
    }
}