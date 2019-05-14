using System;
using System.Linq;
using Application.Interfaces.General;
using Application.Interfaces.User;
using Microsoft.AspNetCore.Mvc;

namespace VcwBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public UsersController(IUserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var user = _userService.GetById(id);

            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }

        [HttpGet]
        public ActionResult Get()
        {
            var users = _userService.GetAll()
                .Where(x => x.Email.Contains("Hossein"));

            return Ok(users);
        }
    }
}