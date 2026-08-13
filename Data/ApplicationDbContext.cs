using Microsoft.EntityFrameworkCore;
using SecureApi.Models;

namespace SecureApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Post> Posts { get; set; }
    }
}