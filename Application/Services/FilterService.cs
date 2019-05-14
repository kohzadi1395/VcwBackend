using System;
using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Application.Interfaces.Challenge;
using Application.Interfaces.Filter;
using Application.Interfaces.Invite;
using Domain.Entities;

namespace Application.Services
{
    public class FilterService : IFilterService
    {
        private readonly IChallengeRepository _challengeRepository;
        private readonly IFilterRepository _filterRepository;
        private readonly IInviteRepository _inviteRepository;

        public FilterService(IFilterRepository filterRepository,
            IInviteRepository inviteRepository,
            IChallengeRepository challengeRepository)
        {
            _filterRepository = filterRepository;
            _inviteRepository = inviteRepository;
            _challengeRepository = challengeRepository;
        }

        public IEnumerable<Filter> GetAllFilters()
        {
            return _filterRepository.GetAll();
        }

        public void Insert(Filter filter)
        {
            _filterRepository.Add(filter);
        }

        public void Insert(ChallengeFilterDto challengeFilterDto)
        {
            var invite = _inviteRepository.Find(x =>
                    x.ChallengeId == challengeFilterDto.Id &&
                    x.UserId == Guid.Parse("8268c85c-6355-4ebd-b498-0d1a8839e052"))
                .FirstOrDefault();
            if (invite == null)
                return;

            foreach (var filter in challengeFilterDto.Filters)
            {
                filter.InviteId = invite.Id;
                var tmpIdea = _filterRepository.GetById(filter.Id);
                if (tmpIdea == null)
                {
                    _filterRepository.Add(filter);
                }
                else
                {
                    tmpIdea.Title = filter.Title;
                    tmpIdea.Description = filter.Description;
                    _filterRepository.Update(tmpIdea);
                }
            }

            var challenge = _challengeRepository.GetById(challengeFilterDto.Id);

            if (challenge.ChallengeState == 3)
                challenge.ChallengeState += 1;
        }
    }
}