using System;
using System.Collections.Generic;
using System.Linq;
using VcwBackend.Core;
using VcwBackend.Models;

namespace VcwBackend.Services
{
    public class IdeaRepository
    {
        private readonly ApiContext _context;

        public IdeaRepository()
        {
            _context = new ApiContext();
        }

        public IEnumerable<Idea> GetAllIdeas()
        {
            var ideas = _context.Ideas.ToList();
            return ideas;
        }


        public IEnumerable<Idea> GetIdea(Guid id)
        {
            var ideas = _context.Ideas
                .Where(x => x.Id == id).ToList();
            return ideas;
        }

        public void Insert(Idea idea)
        {
            _context.Ideas.Add(idea);
            _context.SaveChanges();
        }
    }
}