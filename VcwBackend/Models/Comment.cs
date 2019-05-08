using System;
using System.ComponentModel.DataAnnotations;

namespace VcwBackend.Models
{
    public class Comment : BaseEntity
    {
        public Guid Id { get; set; }

         public string Description { get; set; }

    }
}