using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ecomapp
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> categories { get; set; }
    }
}