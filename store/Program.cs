using store.DTOs;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

List<GameDTO> games = [
    new GameDTO(1, "The Witcher 3: Wild Hunt", "RPG", 29.99m, new DateOnly(2015, 5, 19)),
    new GameDTO(2, "Cyberpunk 2077", "Action RPG", 49.99m, new DateOnly(2020, 12, 10)),
    new GameDTO(3, "DOOM Eternal", "FPS", 39.99m, new DateOnly(2020, 3, 20))
];

app.MapGet("games", () => games);

app.Run();
