using System;
using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces.Challenge;
using Application.Interfaces.IdeaStatus;
using Domain.Entities;

namespace Application.Services
{
    public class IdeaStatusService : IIdeaStatusService
    {
        private readonly IChallengeRepository _challengeRepository;
        private readonly IIdeaStatusRepository _ideaStatusRepository;

        public IdeaStatusService(IIdeaStatusRepository ideaStatusRepository, IChallengeRepository challengeRepository)
        {
            _ideaStatusRepository = ideaStatusRepository;
            _challengeRepository = challengeRepository;
        }

        public ChallengeSelectionIdeaDto GetSelectionIdea(ChallengeSelectionIdeaDto challengeSelectionIdeaDto)
        {
            if (challengeSelectionIdeaDto.Kill == null &&
                challengeSelectionIdeaDto.Keep == null &&
                challengeSelectionIdeaDto.Review == null &&
                challengeSelectionIdeaDto.Multiply == null)
                return GetSelectionIdeaList(challengeSelectionIdeaDto);
            return InsertSelectionIdea(challengeSelectionIdeaDto);
        }

        private ChallengeSelectionIdeaDto GetSelectionIdeaList(ChallengeSelectionIdeaDto challengeSelectionIdeaDto)
        {
            var ideaStatuses = _ideaStatusRepository.GetSelectionIdea(null, challengeSelectionIdeaDto.ChallengeId);
            var reviewIdeas = new List<Idea>();
            var killIdeas = new List<Idea>();
            var keepIdeas = new List<Idea>();
            var multiplyIdeas = new List<Idea>();
            foreach (var ideaStatus in ideaStatuses)
                switch (ideaStatus.Status.Title.ToLower())
                {
                    case "review":
                        reviewIdeas.Add(ideaStatus.Idea);
                        break;
                    case "kill":
                        killIdeas.Add(ideaStatus.Idea);
                        break;
                    case "keep":
                        keepIdeas.Add(ideaStatus.Idea);
                        break;
                    case "multiply":
                        multiplyIdeas.Add(ideaStatus.Idea);
                        break;
                }

            challengeSelectionIdeaDto.Keep = keepIdeas;
            challengeSelectionIdeaDto.Review = reviewIdeas;
            challengeSelectionIdeaDto.Kill = killIdeas;
            challengeSelectionIdeaDto.Multiply = multiplyIdeas;

            return challengeSelectionIdeaDto;
        }

        private ChallengeSelectionIdeaDto InsertSelectionIdea(ChallengeSelectionIdeaDto challengeSelectionIdeaDto)
        {
            foreach (var idea in challengeSelectionIdeaDto.Review)
            {
                var reviewIdea = new IdeaStatus
                {
                    IdeaId = idea.Id,
                    StatusId = Guid.Parse("11f4e235-bbee-4527-a88a-2d239aa91ee6"),
                    UserId = Guid.Parse("5b7127e5-b581-4a87-bbdb-5312b9ded2cc")
                };
                _ideaStatusRepository.Add(reviewIdea);
            }

            foreach (var idea in challengeSelectionIdeaDto.Keep)
            {
                var keepIdea = new IdeaStatus
                {
                    IdeaId = idea.Id,
                    StatusId = Guid.Parse("6b2ac6fa-0895-448b-8016-70b26355b211"),
                    UserId = Guid.Parse("5b7127e5-b581-4a87-bbdb-5312b9ded2cc")
                };
                _ideaStatusRepository.Add(keepIdea);
            }

            foreach (var idea in challengeSelectionIdeaDto.Kill)
            {
                var killIdea = new IdeaStatus
                {
                    IdeaId = idea.Id,
                    StatusId = Guid.Parse("e23a5191-5f41-4c00-b855-d87b14dc9180"),
                    UserId = Guid.Parse("5b7127e5-b581-4a87-bbdb-5312b9ded2cc")
                };
                _ideaStatusRepository.Add(killIdea);
            }

            foreach (var idea in challengeSelectionIdeaDto.Multiply)
            {
                var multiplyIdea = new IdeaStatus
                {
                    IdeaId = idea.Id,
                    StatusId = Guid.Parse("410031b0-0975-4769-88fb-ef742e2f7702"),
                    UserId = Guid.Parse("5b7127e5-b581-4a87-bbdb-5312b9ded2cc")
                };
                _ideaStatusRepository.Add(multiplyIdea);
            }

            var challenge = _challengeRepository.GetById(challengeSelectionIdeaDto.ChallengeId);

            if (challenge.ChallengeState == 4)
                challenge.ChallengeState += 1;
            return challengeSelectionIdeaDto;
        }
    }
}