using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Core
{
    public class RecruiterContext : DbContext
    {
        public RecruiterContext(DbContextOptions<RecruiterContext> options) : base(options)
        {
        }

        public DbSet<Attachment> Resumes { get; set; }
        public DbSet<Category> Cities { get; set; }
        public DbSet<Challenge> Courses { get; set; }
        public DbSet<Comment> EducationalRecords { get; set; }
        public DbSet<ExamIdea> JobCategories { get; set; }
        public DbSet<Filter> JobRecords { get; set; }
        public DbSet<Idea> PersonalInfos { get; set; }
        public DbSet<Invit> SocialNetworks { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecruiterContext).Assembly);
        }
    }
}