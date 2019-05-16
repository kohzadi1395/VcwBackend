using System;
using Application.DTOs;
using Application.Interfaces.General;
using Application.Interfaces.FilterStatus;
using Microsoft.AspNetCore.Mvc;

namespace VcwBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/FilterSelection")]
    public class FilterSelectionController : Controller
    {
        private readonly IFilterStatusService _filterStatusService;
        private readonly IUnitOfWork _unitOfWork;

        public FilterSelectionController(IFilterStatusService filterStatusService, IUnitOfWork unitOfWork)
        {
            _filterStatusService = filterStatusService;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Get([FromBody] ChallengeSelectionFilterDto challengeSelectionFilterDto)
        {
            try
            {
                challengeSelectionFilterDto = _filterStatusService.GetSelectionFilter(challengeSelectionFilterDto);
                _unitOfWork.Commit();
                return Ok(challengeSelectionFilterDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ChallengeSelectionFilterDto challengeSelectionFilterDto)
        {
            try
            {
                challengeSelectionFilterDto = _filterStatusService.GetSelectionFilter(challengeSelectionFilterDto);
                _unitOfWork.Commit();
                return Ok(challengeSelectionFilterDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("InsertFilter")]
        public IActionResult InsertFilter([FromBody] ChallengeFilterDto challengeFilterDto)
        {
            try
            {
                _unitOfWork.Commit();
                return Ok(challengeFilterDto.Id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}