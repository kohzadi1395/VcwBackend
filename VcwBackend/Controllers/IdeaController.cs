using System;
using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories;

namespace VcwBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/Idea")]
    public class IdeaController : Controller
    {
        private readonly IIdeaService _ideaService;
        private IUnitOfWork _unitOfWork;

        public IdeaController(IIdeaService ideaService, IUnitOfWork unitOfWork)
        {
            _ideaService = ideaService;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Idea> Get()
        {
            return _ideaService.GetAllIdeas();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Idea idea)
        {
            _ideaService.Insert(idea);
            _unitOfWork.Commit();
            return Ok(idea.Id);
        }
        [HttpPost("InsertIdea")]
        public IActionResult InsertIdea([FromBody] ChallengeIdeaDto challengeIdeaDto)
        {
            try
            {
                _ideaService.Insert(challengeIdeaDto);
                _unitOfWork.Commit();
                return Ok(challengeIdeaDto.Id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}