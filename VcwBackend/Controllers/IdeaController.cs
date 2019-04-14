using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VcwBackend.Services;

namespace VcwBackend.Controllers
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

        public IEnumerable<Models.Idea> Get()
       {
            return _ideaRepository.GetAllIdeas();
        }

        [HttpPost]
        public void Post([FromBody] Models.Idea idea)
        {
             _ideaRepository.Insert(idea);
        }
    }
}
