using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Application.DTOs;
using Application.Interfaces.Challenge;
using Application.Interfaces.FilterStatus;
using Domain.Entities;

namespace Application.Services
{
    public class FilterStatusService : IFilterStatusService
    {
        private readonly IChallengeRepository _challengeRepository;
        private readonly IFilterStatusRepository _filterStatusRepository;

        public FilterStatusService(IFilterStatusRepository filterStatusRepository,
            IChallengeRepository challengeRepository)
        {
            _filterStatusRepository = filterStatusRepository;
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
        public ChallengeSelectionFilterDto GetSelectionFilter(Guid challengeId)
        {
            var filterStatuses = _filterStatusRepository.GetSelectionFilter(null, challengeId:challengeId);
            var keep = filterStatuses.OrderBy(x => x.Rank).Where(x => x.Status.Title.ToLower() == "keep").Select(x=>x.Filter).ToList();

            var challengeSelectionFilterDto = new ChallengeSelectionFilterDto
            {
                ChallengeId = challengeId,
                Keep = keep
            };
            return challengeSelectionFilterDto;
        }

        public ChallengeSelectionFilterDto UpdateRankFilterStatus(ChallengeSelectionFilterDto challengeSelectionFilterDto)
        {
            for (var index = 0; index < challengeSelectionFilterDto.Keep.Count; index++)
            {
                var filter = challengeSelectionFilterDto.Keep[index];
                var filterStatus = _filterStatusRepository.GetFilterStatus(filter.Id);
                filterStatus.Rank = index + 1;
                _filterStatusRepository.Update(filterStatus);
            }

            var challenge = _challengeRepository.GetById(challengeSelectionFilterDto.ChallengeId);

            if (challenge.ChallengeState == 6)
                challenge.ChallengeState += 1;

            return challengeSelectionFilterDto;
        }

        private ChallengeSelectionFilterDto GetSelectionFilterList(
            ChallengeSelectionFilterDto challengeSelectionFilterDto)
        {
            var filterStatuses = _filterStatusRepository.GetSelectionFilter(null, challengeSelectionFilterDto.ChallengeId);
            var reviewFilters = new List<Filter>();
            var killFilters = new List<Filter>();
            var keepFilters = new List<Filter>();
            var multiplyFilters = new List<Filter>();
            foreach (var filterStatus in filterStatuses.Where(y=>y.Rank!=0).OrderBy(x=>x.Rank))
                switch (filterStatus.Status.Title.ToLower())
                {
                    case "review":
                        reviewFilters.Add(filterStatus.Filter);
                        break;
                    case "kill":
                        killFilters.Add(filterStatus.Filter);
                        break;
                    case "keep":
                        keepFilters.Add(filterStatus.Filter);
                        break;
                    case "multiply":
                        multiplyFilters.Add(filterStatus.Filter);
                        break;
                }


            challengeSelectionFilterDto.Keep = keepFilters.ToList();
            challengeSelectionFilterDto.Review = reviewFilters;
            challengeSelectionFilterDto.Kill = killFilters;
            challengeSelectionFilterDto.Multiply = multiplyFilters;

            return challengeSelectionFilterDto;
        }

        private ChallengeSelectionFilterDto InsertSelectionFilter(
            ChallengeSelectionFilterDto challengeSelectionFilterDto)
        {
            foreach (var filter in challengeSelectionFilterDto.Review)
            {
                var reviewFilter = new FilterStatus
                {
                    FilterId = filter.Id,
                    StatusId = Guid.Parse("11f4e235-bbee-4527-a88a-2d239aa91ee6"),
                    UserId = Guid.Parse("5b7127e5-b581-4a87-bbdb-5312b9ded2cc")
                };
                _filterStatusRepository.Add(reviewFilter);
            }

            foreach (var filter in challengeSelectionFilterDto.Keep)
            {
                var keepFilter = new FilterStatus
                {
                    FilterId = filter.Id,
                    StatusId = Guid.Parse("6b2ac6fa-0895-448b-8016-70b26355b211"),
                    UserId = Guid.Parse("5b7127e5-b581-4a87-bbdb-5312b9ded2cc")
                };
                _filterStatusRepository.Add(keepFilter);
            }

            foreach (var filter in challengeSelectionFilterDto.Kill)
            {
                var killFilter = new FilterStatus
                {
                    FilterId = filter.Id,
                    StatusId = Guid.Parse("e23a5191-5f41-4c00-b855-d87b14dc9180"),
                    UserId = Guid.Parse("5b7127e5-b581-4a87-bbdb-5312b9ded2cc")
                };
                _filterStatusRepository.Add(killFilter);
            }

            foreach (var filter in challengeSelectionFilterDto.Multiply)
            {
                var multiplyFilter = new FilterStatus
                {
                    FilterId = filter.Id,
                    StatusId = Guid.Parse("410031b0-0975-4769-88fb-ef742e2f7702"),
                    UserId = Guid.Parse("5b7127e5-b581-4a87-bbdb-5312b9ded2cc")
                };
                _filterStatusRepository.Add(multiplyFilter);
            }

            var challenge = _challengeRepository.GetById(challengeSelectionFilterDto.ChallengeId);

            if (challenge.ChallengeState == 5)
                challenge.ChallengeState += 1;
            return challengeSelectionFilterDto;
        }
    }
}