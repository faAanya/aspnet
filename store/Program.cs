using store.DTOs;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string GetGameEndPointName = "GetGame";

List<GameDTO> games = [
    new GameDTO(1, "The Witcher 3: Wild Hunt", "RPG", 29.99m, new DateOnly(2015, 5, 19)),
    new GameDTO(2, "Cyberpunk 2077", "Action RPG", 49.99m, new DateOnly(2020, 12, 10)),
    new GameDTO(3, "DOOM Eternal", "FPS", 39.99m, new DateOnly(2020, 3, 20))
];

//GET /games
app.MapGet("games", () => games);

//GET /games/1
app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id)).WithName(GetGameEndPointName);

//POST /games
app.MapPost("games", (CreateGameDTO newGame) =>
{
    GameDTO game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );

    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game);
});

app.MapPut("games/{id}", (int id, UpdateGameDTO updatedGame) =>
{
    var index = games.FindIndex(game => game.Id == id);

    games[index] = new GameDTO(
        id,
        updatedGame.Name,
        updatedGame.Genre,
        updatedGame.Price,
        updatedGame.ReleaseDate
        );

    return Results.NoContent();
});

//DELETE /games/1
app.MapDelete("games/{id}", (int id) =>
{
    games.RemoveAll(game => game.Id == id);

    return Results.NoContent();

});
app.Run();
