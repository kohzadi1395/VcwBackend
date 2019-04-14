using System;
using System.ComponentModel.DataAnnotations;

namespace VcwBackend.Models
{
    public class Comment
    {
        public Guid Id { get; set; }

         public string Description { get; set; }

        public Guid? TableId { get; set; }
    }
}