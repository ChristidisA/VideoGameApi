using VideoGameApi.Core.Accessors;
using VideoGameApi.Core.Repositories;
using VideoGameApi.Web.VideoGames.Services;

namespace VideoGameApi;

public class ClassScopes
{
    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IVideoGameAccessor, VideoGameRepository>();
        builder.Services.AddScoped<IAddGameService, AddGameService>();
        builder.Services.AddScoped<IListGamesService, ListGamesService>();
        builder.Services.AddScoped<IUpdateGameService, UpdateGameService>();
        builder.Services.AddScoped<IDeleteGameService, DeleteGameService>();
        builder.Services.AddScoped<IGetGameService, GetGameService>();
    }
}