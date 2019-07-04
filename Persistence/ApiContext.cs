using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ApiContext : DbContext
    {
//        public ApiContext()
//        {
//            
//        }
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }


        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Challenge> Challenges { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Filter> Filters { get; set; }
        public virtual DbSet<Idea> Ideas { get; set; }
        public virtual DbSet<Invite> Invites { get; set; }
        public virtual DbSet<FilterStatus> FilterStatuses { get; set; }
        public virtual DbSet<IdeaStatus> IdeaStatuses { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<FilterIdeaPassed> FilterIdeaPasseds { get; set; }
        
//        protected override void OnConfiguring(DbContextOptionsBuilder builder)
//        {
//            //builder.UseSqlServer("Data Source=.;Initial Catalog=VCW;Integrated Security=True");
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiContext).Assembly);
        }
    }
}