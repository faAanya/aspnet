using Microsoft.EntityFrameworkCore;
using store.Entities;

namespace store.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options)
: DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();

}
