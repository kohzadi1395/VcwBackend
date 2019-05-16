using System;
using Application.DTOs;
using Application.Interfaces.General;
using Application.Interfaces.IdeaStatus;
using Microsoft.AspNetCore.Mvc;

namespace VcwBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/IdeaSelection")]
    public class IdeaSelectionController : Controller
    {
        private readonly IIdeaStatusService _ideaStatusService;
        private readonly IUnitOfWork _unitOfWork;

        public IdeaSelectionController(IIdeaStatusService ideaStatusService, IUnitOfWork unitOfWork)
        {
            _ideaStatusService = ideaStatusService;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Get([FromBody] ChallengeSelectionIdeaDto challengeSelectionIdeaDto)
        {
            try
            {
                challengeSelectionIdeaDto = _ideaStatusService.GetSelectionIdea(challengeSelectionIdeaDto);
                _unitOfWork.Commit();
                return Ok(challengeSelectionIdeaDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ChallengeSelectionIdeaDto challengeSelectionIdeaDto)
        {
            try
            {
                challengeSelectionIdeaDto = _ideaStatusService.GetSelectionIdea(challengeSelectionIdeaDto);
                _unitOfWork.Commit();
                return Ok(challengeSelectionIdeaDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("InsertIdea")]
        public IActionResult InsertIdea([FromBody] ChallengeIdeaDto challengeIdeaDto)
        {
            try
            {
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