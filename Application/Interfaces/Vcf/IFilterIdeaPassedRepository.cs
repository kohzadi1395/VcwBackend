using System;
using Application.Interfaces.General;
using Domain.Entities;

namespace Application.Interfaces.Vcf
{
    public interface IFilterIdeaPassedRepository : IRepository<FilterIdeaPassed>
    {
        FilterIdeaPassed GetFilterIdea(Guid ideaId,
            Guid filterId,
            Guid userId);

    }
}