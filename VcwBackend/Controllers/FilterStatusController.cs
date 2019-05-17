using System;
using Application.DTOs;
using Application.Interfaces.FilterStatus;
using Application.Interfaces.General;
using Microsoft.AspNetCore.Mvc;

namespace VcwBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/FilterStatus")]
    public class FilterStatusController : Controller
    {
        private readonly IFilterStatusService _filterStatusService;
        private readonly IUnitOfWork _unitOfWork;

        public FilterStatusController(IFilterStatusService filterStatusService, IUnitOfWork unitOfWork)
        {
            _filterStatusService = filterStatusService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ChallengeSelectionFilterDto challengeSelectionFilterDto)
        {
            try
            {
                challengeSelectionFilterDto = _filterStatusService.UpdateRankFilterStatus(challengeSelectionFilterDto);
                _unitOfWork.Commit();
                return Ok(challengeSelectionFilterDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var selectionFilter = _filterStatusService.GetSelectionFilter(id);
                return Ok(selectionFilter);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}