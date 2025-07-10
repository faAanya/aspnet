using store.DTOs;
using store.Entities;

namespace store.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this CreateGameDTO gameDTO)
    {
        return new Game()
        {
            Name = gameDTO.Name,
            GenreID = gameDTO.GenreId,
            Price = gameDTO.Price,
            ReleaseDate = gameDTO.ReleaseDate
        };
    }

    public static GameDTO ToDTO(this Game game)
    {
        return new(
               game.Id,
               game.Name,
               game.Genre!.Name,
               game.Price,
               game.ReleaseDate
           );
    }
}