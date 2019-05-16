using System;
using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces.Challenge;
using Application.Interfaces.FilterStatus;
using Domain.Entities;

namespace Application.Services
{
    public class FilterStatusService : IFilterStatusService
    {
        private readonly IFilterStatusRepository _ideaStatusRepository;
        private readonly IChallengeRepository _challengeRepository;

        public FilterStatusService(IFilterStatusRepository ideaStatusRepository, IChallengeRepository challengeRepository)
        {
            _ideaStatusRepository = ideaStatusRepository;
            _challengeRepository = challengeRepository;
        }

        public ChallengeSelectionFilterDto GetSelectionFilter(ChallengeSelectionFilterDto challengeSelectionFilterDto)
        {
            if (challengeSelectionFilterDto.Kill == null &&
                challengeSelectionFilterDto.Keep == null &&
                challengeSelectionFilterDto.Review == null &&
                challengeSelectionFilterDto.Multiply == null)
                return GetSelectionFilterList(challengeSelectionFilterDto);
            return InsertSelectionFilter(challengeSelectionFilterDto);
        }

        private ChallengeSelectionFilterDto GetSelectionFilterList(ChallengeSelectionFilterDto challengeSelectionFilterDto)
        {
            var ideaStatuses = _ideaStatusRepository.GetSelectionFilter(null, challengeSelectionFilterDto.ChallengeId);
            var reviewFilters = new List<Filter>();
            var killFilters = new List<Filter>();
            var keepFilters = new List<Filter>();
            var multiplyFilters = new List<Filter>();
            foreach (var ideaStatus in ideaStatuses)
                switch (ideaStatus.Status.Title.ToLower())
                {
                    case "review":
                        reviewFilters.Add(ideaStatus.Filter);
                        break;
                    case "kill":
                        killFilters.Add(ideaStatus.Filter);
                        break;
                    case "keep":
                        keepFilters.Add(ideaStatus.Filter);
                        break;
                    case "multiply":
                        multiplyFilters.Add(ideaStatus.Filter);
                        break;
                }

            challengeSelectionFilterDto.Keep = keepFilters;
            challengeSelectionFilterDto.Review = reviewFilters;
            challengeSelectionFilterDto.Kill = killFilters;
            challengeSelectionFilterDto.Multiply = multiplyFilters;

            return challengeSelectionFilterDto;
        }

        private ChallengeSelectionFilterDto InsertSelectionFilter(ChallengeSelectionFilterDto challengeSelectionFilterDto)
        {
            foreach (var idea in challengeSelectionFilterDto.Review)
            {
                var reviewFilter = new FilterStatus
                {
                    FilterId = idea.Id,
                    StatusId = Guid.Parse("11f4e235-bbee-4527-a88a-2d239aa91ee6"),
                    UserId = Guid.Parse("5b7127e5-b581-4a87-bbdb-5312b9ded2cc")
                };
                _ideaStatusRepository.Add(reviewFilter);
            }

            foreach (var idea in challengeSelectionFilterDto.Keep)
            {
                var keepFilter = new FilterStatus
                {
                    FilterId = idea.Id,
                    StatusId = Guid.Parse("6b2ac6fa-0895-448b-8016-70b26355b211"),
                    UserId = Guid.Parse("5b7127e5-b581-4a87-bbdb-5312b9ded2cc")
                };
                _ideaStatusRepository.Add(keepFilter);
            }

            foreach (var idea in challengeSelectionFilterDto.Kill)
            {
                var killFilter = new FilterStatus
                {
                    FilterId = idea.Id,
                    StatusId = Guid.Parse("e23a5191-5f41-4c00-b855-d87b14dc9180"),
                    UserId = Guid.Parse("5b7127e5-b581-4a87-bbdb-5312b9ded2cc")
                };
                _ideaStatusRepository.Add(killFilter);
            }

            foreach (var idea in challengeSelectionFilterDto.Multiply)
            {
                var multiplyFilter = new FilterStatus
                {
                    FilterId = idea.Id,
                    StatusId = Guid.Parse("410031b0-0975-4769-88fb-ef742e2f7702"),
                    UserId = Guid.Parse("5b7127e5-b581-4a87-bbdb-5312b9ded2cc")
                };
                _ideaStatusRepository.Add(multiplyFilter);
            }
            var challenge = _challengeRepository.GetById(challengeSelectionFilterDto.ChallengeId);

            if (challenge.ChallengeState == 3)
                challenge.ChallengeState += 1;
            return challengeSelectionFilterDto;
        }
    }
}