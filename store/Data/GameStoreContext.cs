using Microsoft.EntityFrameworkCore;
using store.Entities;

namespace store.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options)
: DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
     new { Id = 1, Name = "Crafting" },
     new { Id = 2, Name = "RPG" },
     new { Id = 3, Name = "Shooter" },
     new { Id = 4, Name = "Strategy" },
     new { Id = 5, Name = "Adventure" },
     new { Id = 6, Name = "Puzzle" },
     new { Id = 7, Name = "Simulation" },
     new { Id = 8, Name = "Survival" },
     new { Id = 9, Name = "Platformer" },
     new { Id = 10, Name = "Fighting" },
     new { Id = 11, Name = "Racing" },
     new { Id = 12, Name = "Horror" },
     new { Id = 13, Name = "Stealth" },
     new { Id = 14, Name = "MMO" },
     new { Id = 15, Name = "Idle" },
     new { Id = 16, Name = "Sandbox" },
     new { Id = 17, Name = "Metroidvania" },
     new { Id = 18, Name = "Visual Novel" },
     new { Id = 19, Name = "Music" },
     new { Id = 20, Name = "Sports" }
 );
    }

}
