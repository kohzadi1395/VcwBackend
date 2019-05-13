using System.Collections.Generic;
using Domain.Entities;

namespace Application.DTOs
{
    public class ChallengeUserGetDto : Challenge
    {
        public List<User> InvitePerson { get; set; }
        public List<Idea> Ideas { get; set; }
        public List<Filter> Filters { get; set; }
    }
}