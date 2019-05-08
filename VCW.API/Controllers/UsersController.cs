using System;
using System.Threading.Tasks;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly UserRepository repository;

        public UsersController()
        {
            repository = new UserRepository();
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var user = repository.GetUser(id);

            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }

        [HttpGet]
        public ActionResult Get()
        {
            var users = repository.GetAllUsers();

            if (users == null)
                return NotFound("User not found");

            return Ok(users);
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var users = repository.GetAllUsers();

            if (users == null)
                return NotFound("User not found");

            return Ok(users);
        }
    }
}