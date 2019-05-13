using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Application.DTOs
{
    public class ChallengeUserPostDto : Challenge
    {
        public List<Guid> InvitePersonId { get; set; }
    }
}