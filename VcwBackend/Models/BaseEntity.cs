using System;

namespace VcwBackend.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifDate { get; set; }
        public bool Deleted { get; set; }
    }
}