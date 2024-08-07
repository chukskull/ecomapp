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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string[] seeds = { "Action", "ScFi", "History" };
            var cats = seeds.Select((name, index) => new Category
            {
                Id = index + 1,
                Name = name,
                DisplayOrder = index + 1

            }).ToArray<Category>();
            modelBuilder.Entity<Category>().HasData(cats);
        }
    }
}