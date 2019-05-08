using System.Collections.Generic;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Idea")]
    public class IdeaController : Controller
    {
        private readonly IdeaRepository _ideaRepository;

        public IdeaController()
        {
            _ideaRepository = new IdeaRepository();
        }

        public IEnumerable<Idea> Get()
        {
            return _ideaRepository.GetAllIdeas();
        }

        [HttpPost]
        public void Post([FromBody] Idea idea)
        {
            _ideaRepository.Insert(idea);
        }
    }
}