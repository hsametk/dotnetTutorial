using GameStore.Api.Data;
using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

//Validation
builder.Services.AddValidation();

builder.AddGameStoreDb();

var app = builder.Build();

app.MigrateDb();

app.MapGamesEndpoints();
app.MapGenresEndpoints();
app.Run();
