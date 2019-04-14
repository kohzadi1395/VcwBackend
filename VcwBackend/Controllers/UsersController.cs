using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VcwBackend.Core;
using VcwBackend.Services;

namespace VcwBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        readonly UserRepository repository;

        public UsersController()
        {
            this.repository = new UserRepository();
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
    }
}