using System;
using System.Collections.Generic;
using Application.Interfaces.General;

namespace Application.Interfaces.FilterStatus
{
    public interface IFilterStatusRepository : IRepository<Domain.Entities.FilterStatus>
    {
        List<Domain.Entities.FilterStatus> GetSelectionFilter(Guid? userId, Guid challengeId);
        Domain.Entities.FilterStatus GetFilterStatus(Guid filterId);
    }
}