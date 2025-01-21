using Microsoft.EntityFrameworkCore;
using project_name.Models;

namespace project_name.Data
{
    public class WebAppDbContext : DbContext
    {
        public WebAppDbContext(DbContextOptions<WebAppDbContext> options) : base(options)
        {

            
        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Category>().HasData(
               new Category { Id = 1, Name = "Action", DisplayOrder = 1},
               new Category { Id = 2, Name = "History", DisplayOrder = 2 },
               new Category { Id = 3, Name = "Math", DisplayOrder = 3 }

               );
        }
    }
}
