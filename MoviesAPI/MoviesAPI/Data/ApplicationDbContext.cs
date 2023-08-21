using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;
namespace MoviesAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            base.OnModelCreating(ModelBuilder);

            ModelBuilder.Entity<Movie>().
                HasData(
                new Movie { Id = 1, Title = "The Matrix", RunningTime = 127, Genre = "Action" },
                new Movie { Id = 2, Title = "Jurrasic Park", RunningTime = 127, Genre = "Action" },
                new Movie { Id = 3, Title = "Shrek", RunningTime = 90, Genre = "Animation" },
                new Movie { Id = 4, Title = "Hereditary", RunningTime = 127, Genre = "Horror" }
                );
        }
    }
}
