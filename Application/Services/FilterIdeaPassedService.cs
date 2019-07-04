using Application.DTOs;
using Application.Interfaces.FilterStatus;
using Application.Interfaces.IdeaStatus;
using Application.Interfaces.Vcf;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Challenge;
using Application.Interfaces.Filter;
using Application.Interfaces.Idea;

namespace Application.Services
{
    public class FilterIdeaPassedService : IFilterIdeaPassedService
    {
        private readonly IFilterIdeaPassedRepository _filterIdeaPassedRepository;
        private readonly IChallengeRepository _challengeRepository;
        private readonly IFilterStatusService _filterStatusService;
        private readonly IFilterStatusRepository _filterStatusRepository;
        private readonly IIdeaStatusService _ideaStatusService;
        private readonly IIdeaStatusRepository _ideaStatusRepository;

        public FilterIdeaPassedService(
            IFilterStatusService filterStatusService,
            IFilterStatusRepository filterStatusRepository,
            IIdeaStatusService ideaStatusService,
            IIdeaStatusRepository ideaStatusRepository,
            IFilterIdeaPassedRepository filterIdeaPassed,
            IChallengeRepository challengeRepository
        )
        {
            _filterStatusService = filterStatusService;
            _filterStatusRepository = filterStatusRepository;
            _ideaStatusService = ideaStatusService;
            _ideaStatusRepository = ideaStatusRepository;
            _filterIdeaPassedRepository = filterIdeaPassed;
            _challengeRepository = challengeRepository;
        }

        private FilterStatus GetFilterStatus(Guid filterId)
        {
            return _filterStatusRepository.GetFilterStatus(filterId);
        }

        private IdeaStatus GetIdeaStatus(Guid ideaId)
        {
            return _ideaStatusRepository.GetIdeaStatus(ideaId);
        }

        private FilterIdeaPassed GetFilterIdea(IdeaStatus ideaStatus, FilterStatus filterStatus, Guid userId)
        {
            var filterIdeaPassed = _filterIdeaPassedRepository.GetFilterIdea(ideaStatus.Id,
                                                                             filterStatus.Id,
                                                                                  userId);
            return filterIdeaPassed;
        }

        public FilterIdeaDto GetFilterIdea(Guid challengeId)
        {
            var selectionFilterDto = new ChallengeSelectionFilterDto { ChallengeId = challengeId };
            var selectionIdeaDto = new ChallengeSelectionIdeaDto { ChallengeId = challengeId };
            var challengeSelectionFilterDto = _filterStatusService.GetSelectionFilter(selectionFilterDto);
            var challengeSelectionIdeaDto = _ideaStatusService.GetSelectionIdea(selectionIdeaDto);
            var filterIdeaDto = new FilterIdeaDto
            {
                ChallengeId = challengeId,
                FilterPasseds = new List<FilterPassedDto>()
            };
            foreach (var filter in challengeSelectionFilterDto.Keep)
            {
                var tmpFilter = new Filter
                {
                    Id=filter.Id,
                    Title = filter.Title,
                    Description = filter.Description
                };
                var filterPassedDto = new FilterPassedDto
                {
                    Filter = tmpFilter,
                    Ideas = challengeSelectionIdeaDto.Keep.Select(x => new Idea
                    {
                        Id=x.Id,
                        Title = x.Title,
                        Description = x.Description
                    }).ToList()
                };
                filterIdeaDto.FilterPasseds.Add(filterPassedDto);
            }

            return filterIdeaDto;
        }

        public void InsertFilterIdea(ChallengePostVcfDto postVcfDto)
        {
            foreach (var resultDto in postVcfDto.VcfResultDtOs)
            {
                var filterStatus = GetFilterStatus(resultDto.FilterId);
                var ideaStatus = GetIdeaStatus(resultDto.IdeaId);
                if (filterStatus != null && ideaStatus != null)
                {
                    var filterIdeaPassed = GetFilterIdea(ideaStatus, filterStatus,
                        Guid.Parse("5b7127e5-b581-4a87-bbdb-5312b9ded2cc"));
                    if (filterIdeaPassed != null)
                    {
                        filterIdeaPassed.Passed = resultDto.IsPassed;
                        _filterIdeaPassedRepository.Update(filterIdeaPassed);
                    }
                    else
                    {
                        var ideaPassed = new FilterIdeaPassed
                        {
                            FilterStatusId=filterStatus.Id,
                            IdeaStatusId=ideaStatus.Id,
                            Passed= resultDto.IsPassed
                        };
                        _filterIdeaPassedRepository.Add(ideaPassed);
                    }
                }
            }
            var challenge = _challengeRepository.GetById(postVcfDto.ChallengeId);
            if (challenge.ChallengeState == 7)
                challenge.ChallengeState += 1;
        }
    }
}