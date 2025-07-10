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

    public static Game ToEntity(this UpdateGameDTO gameDTO, int id)
    {
        return new Game()
        {
            Id = id,
            Name = gameDTO.Name,
            GenreID = gameDTO.GenreId,
            Price = gameDTO.Price,
            ReleaseDate = gameDTO.ReleaseDate
        };
    }

    public static GameSummaryDTO ToGameSummaryDTO(this Game game)
    {
        return new(
               game.Id,
               game.Name,
               game.Genre!.Name,
               game.Price,
               game.ReleaseDate
           );
    }

     public static GameDetailsDTO ToGameDetailsDTO(this Game game)
    {
        return new(
               game.Id,
               game.Name,
               game.GenreID,
               game.Price,
               game.ReleaseDate
           );
    }
}