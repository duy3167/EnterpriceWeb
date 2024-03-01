using Microsoft.EntityFrameworkCore;

namespace EnterpriceWeb.Models
{
    public class AppDbConText : DbContext
    {
        public AppDbConText(DbContextOptions options) : base(options) { }
        public DbSet<User> users { get; set; }
        public DbSet<Faculty> faculties { get; set; }
        //public DbSet<Article> articles { get; set; }
        //public DbSet<Article_file> article_Files { get; set; }
        //public DbSet<Feedback> feedbacks { get; set; }
        //public DbSet<Magazine> magazines { get; set; }
    }
}
