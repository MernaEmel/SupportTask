using Microsoft.EntityFrameworkCore;
using SupportTask.Models;

namespace SupportTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Company> companies { get; set; }
        public DbSet<Product> products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "nike"   },
                new Company { Id = 2, Name = "adidas" }
                );
        }
    }
}


