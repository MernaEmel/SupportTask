using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SupportTask.Models;

namespace ProjectPages.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        internal object companies;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Company> Companies{get;set;}
        public DbSet<Product> Products { get;set;}

    }
}
