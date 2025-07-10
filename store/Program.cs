using store.Data;
using store.DTOs;
using store.Endpoints;
using store.Entities;
var builder = WebApplication.CreateBuilder(args);


//Connecting the database to app
var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();

app.MapGamesEndpoints();

app.MigrateDb();

app.Run();
