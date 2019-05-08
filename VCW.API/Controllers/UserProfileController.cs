using System;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly UserRepository repository;


        public UserProfileController()
        {
            repository = new UserRepository();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = repository.GetAllUsers().Take(5).Select(x => new UserProfile
                {
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Id = x.Id,
                    Password = x.Password,
                    Username = x.Username,
                    Company = x.Company,
                    Title = x.Title
                });


                if (users == null)
                    return NotFound("User not found");
                var userProfiles = users.ToList();
                for (var i = 0; i < userProfiles.Count; i++) userProfiles[i].Image = $"c{i + 1}.jpg";

                return Ok(userProfiles);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [DisableCors]
        public IActionResult Post([FromBody] UserSearch userSearch)
        {
            try
            {
                var users = repository.GetAllUsers().Take(5).Select(x => new UserProfile
                {
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Id = x.Id,
                    Password = x.Password,
                    Username = x.Username
                });


                if (users == null)
                    return NotFound("User not found");

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }

    public class UserSearch
    {
        public string[] Tags { get; set; }
        public string Name { get; set; }
    }
}