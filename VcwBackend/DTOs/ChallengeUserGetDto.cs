using System;
using System.Collections.Generic;
using VcwBackend.Models;

namespace VcwBackend.DTOs
{
    public class ChallengeUserGetDto : Challenge
    {
        public List<User> InvitePerson { get; set; }
        public List<Idea> Ideas { get; set; }
        public List<Filter> Filters { get; set; }
    }

    public class ChallengeUserPostDto : Challenge
    {
        public List<Guid> InvitePersonId { get; set; }
    }

    public class ChallengeIdeaDto : Challenge
    {
        public List<Idea> Ideas { get; set; }
    }
    public class ChallengeFilterDto : Challenge
    {
        public List<Filter> Filters { get; set; }
    }
}