using System;
using System.Collections.Generic;
using VcwBackend.Models;

namespace VcwBackend.DTOs
{
    public class ChallengeUserGetDto : Challenge
    {
        public List<User> InvitePerson { get; set; }
    }
    public class ChallengeUserPostDto : Challenge
    {
        public List<Guid> InvitePersonId { get; set; }
    }
}