using Microsoft.EntityFrameworkCore;
using VcwBackend.Models;

namespace VcwBackend.Core
{
    public class ApiContext : DbContext
    {
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Challenge> Challenges { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Filter> Filters { get; set; }
        public virtual DbSet<Idea> Ideas { get; set; }
        public virtual DbSet<Invite> Invites { get; set; }
        public virtual DbSet<User> Users { get; set; }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=VCW;Integrated Security=True");
        }
    }
}