using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using VideoGameApi.Core.Accessors;
using VideoGameApi.Core.Repositories;
using VideoGameApi.Data.DataBase;
using VideoGameApi.Web.VideoGames.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<VideoGameDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString(name: "DefaultConnection")));


builder.Services.AddScoped<VideoGameAccessor, VideoGameRepository>();
builder.Services.AddScoped<IAddGameService,AddGameService>();
builder.Services.AddScoped<IListGamesService,ListGamesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();