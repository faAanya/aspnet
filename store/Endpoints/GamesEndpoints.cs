using Microsoft.EntityFrameworkCore;
using store.Data;
using store.DTOs;
using store.Entities;
using store.Mapping;
namespace store.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndPointName = "GetGame";
    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation(); ;

        //GET /games
        group.MapGet("/", (GameStoreContext dbContext) =>
        dbContext.Games.Include(game => game.Genre).Select(game => game.ToGameSummaryDTO()).AsNoTracking());

        //GET /games/1
        group.MapGet("/{id}", (int id, GameStoreContext dbContext) =>
        {
            Game? game = dbContext.Games.Find(id);

            return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDTO());

        }).WithName(GetGameEndPointName);

        //POST /games
        group.MapPost("/", (CreateGameDTO newGame, GameStoreContext dbContext) =>
        {
            Game game = newGame.ToEntity();

            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(
            GetGameEndPointName,
            new { id = game.Id },
            game.ToGameDetailsDTO());
        });
        group.MapPut("/{id}", (int id, UpdateGameDTO updatedGame, GameStoreContext dbContext) =>
        {
            var existingGame = dbContext.Games.Find(id);

            if (existingGame is null)
            {
                return Results.NotFound();
            }
            dbContext.Entry(existingGame).CurrentValues.SetValues(updatedGame.ToEntity(id));
            dbContext.SaveChanges();
            return Results.NoContent();
        });

        //DELETE /games/1
        group.MapDelete("/{id}", (int id, GameStoreContext dbContext) =>
        {
            dbContext.Games.Where(game => game.Id == id).ExecuteDelete();

            return Results.NoContent();

        });

        return group;
    }
}
