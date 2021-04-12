using Microsoft.EntityFrameworkCore;

namespace EFPart1.DataModels
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs {get; set; }
        public DbSet<Post> Posts {get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
            @"Server=bitsql.wctc.edu;Database=ldh_22097_Blogging;User ID=lhernandez19;Password=000557680"
            );
        }
    }
}
