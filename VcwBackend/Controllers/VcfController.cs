using System;
using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces.FilterStatus;
using Application.Interfaces.General;
using Application.Interfaces.IdeaStatus;
using Application.Interfaces.Vcf;
using Microsoft.AspNetCore.Mvc;

namespace VcwBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VcfController : ControllerBase
    {
        private readonly IFilterIdeaPassedService _filterIdeaPassedService;
        private readonly IUnitOfWork _unitOfWork;

        public VcfController(
            IFilterIdeaPassedService filterIdeaPassedService,
            IUnitOfWork unitOfWork)
        {
            _filterIdeaPassedService = filterIdeaPassedService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var filterIdeaDto = _filterIdeaPassedService.GetFilterIdea(id);
                return Ok(filterIdeaDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] ChallengePostVcfDto challengePostVcfDto)
        {
            try
            {
                _filterIdeaPassedService.InsertFilterIdea(challengePostVcfDto);
                _unitOfWork.Commit();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}