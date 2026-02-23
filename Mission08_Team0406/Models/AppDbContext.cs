using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0406.Models
{
    // Consolidated DbContext for the application. This context stores TaskItem entities.
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Tasks DbSet stores the TaskItem entities in the SQLite database.
        public DbSet<TaskItem> Tasks { get; set; }

        // Categories DbSet maps the Categories table in the DB
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
            );
        }
    }
}
