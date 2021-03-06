﻿using System;
using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Application.Interfaces.Challenge;
using Application.Interfaces.Idea;
using Application.Interfaces.Invite;
using Domain.Entities;

namespace Application.Services
{
    public class IdeaService : IIdeaService
    {
        private readonly IChallengeRepository _challengeRepository;
        private readonly IIdeaRepository _ideaRepository;
        private readonly IInviteRepository _inviteRepository;

        public IdeaService(IIdeaRepository ideaRepository,
            IInviteRepository inviteRepository,
            IChallengeRepository challengeRepository)
        {
            _ideaRepository = ideaRepository;
            _inviteRepository = inviteRepository;
            _challengeRepository = challengeRepository;
        }

        public IEnumerable<Idea> GetAllIdeas()
        {
            return _ideaRepository.GetAll();
        }

        public void Insert(Idea idea)
        {
            _ideaRepository.Add(idea);
        }

        public void Insert(ChallengeIdeaDto challengeIdeaDto)
        {
            var invite = _inviteRepository.Find(x =>
                    x.ChallengeId == challengeIdeaDto.Id &&
                    x.UserId == Guid.Parse("8268c85c-6355-4ebd-b498-0d1a8839e052"))
                .FirstOrDefault();
            if (invite == null)
                return;

            foreach (var idea in challengeIdeaDto.Ideas)
            {
                idea.InviteId = invite.Id;
                var tmpIdea = _ideaRepository.GetById(idea.Id);
                if (tmpIdea == null)
                {
                    _ideaRepository.Add(idea);
                }
                else
                {
                    tmpIdea.Title = idea.Title;
                    tmpIdea.Description = idea.Description;
                    _ideaRepository.Update(tmpIdea);
                }
            }

            var challenge = _challengeRepository.GetById(challengeIdeaDto.Id);

            if (challenge.ChallengeState == 2)
                challenge.ChallengeState += 1;
        }
    }
}