using System;
using System.Collections.Generic;
using Application.Interfaces.General;

namespace Application.Interfaces.IdeaStatus
{
    public interface IIdeaStatusRepository : IRepository<Domain.Entities.IdeaStatus>
    {
        List<Domain.Entities.IdeaStatus> GetSelectionIdea(Guid? userId, Guid challengeId);
        Domain.Entities.IdeaStatus GetIdeaStatus(Guid ideaId);

    }
}