using System;
using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces.Filter;
using Application.Interfaces.General;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace VcwBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/Filter")]
    public class FilterController : Controller
    {
        private readonly IFilterService _filterService;
        private readonly IUnitOfWork _unitOfWork;

        public FilterController(IFilterService filterService, IUnitOfWork unitOfWork)
        {
            _filterService = filterService;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Filter> Get()
        {
            return _filterService.GetAllFilters();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Filter filter)
        {
            _filterService.Insert(filter);
            _unitOfWork.Commit();
            return Ok(filter.Id);
        }

        [HttpPost("InsertFilter")]
        public IActionResult InsertFilter([FromBody] ChallengeFilterDto challengeFilterDto)
        {
            try
            {
                _filterService.Insert(challengeFilterDto);
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