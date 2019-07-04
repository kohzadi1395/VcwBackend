using System.Collections.Generic;
using Domain.Entities;

namespace Application.DTOs
{
    public class FilterPassedDto
    {
        public Filter Filter { get; set; }
        public List<Idea> Ideas { get; set; }
    }
}