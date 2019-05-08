using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Core
{
    public class ApiContext : DbContext
    {
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Challenge> Challenges { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<ExamIdea> ExamIdeas { get; set; }
        public virtual DbSet<Filter> Filters { get; set; }
        public virtual DbSet<Idea> Ideas { get; set; }
        public virtual DbSet<Invit> Invites { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=VCW;Integrated Security=True");
        }
    }

//    public class Blog
//    {
//        public int BlogId { get; set; }
//        public string Url { get; set; }
//
//        public ICollection<Post> Posts { get; set; }
//    }
//
//    public class Post
//    {
//        public int PostId { get; set; }
//        public string Title { get; set; }
//        public string Content { get; set; }
//
//        public int BlogId { get; set; }
//        public Blog Blog { get; set; }
//    }
}