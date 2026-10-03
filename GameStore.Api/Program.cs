using GameStore.Api.Dtos;
using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

//Validation
builder.Services.AddValidation();

var app = builder.Build();

app.MapGamesEndpoints();
app.Run();
