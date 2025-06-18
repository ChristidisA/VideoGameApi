using VideoGameApi.Core.Accessors;
using VideoGameApi.Data.Dtos;

namespace VideoGameApi.Web.VideoGames.Services;

public interface IGetGameService
{
    Task<VideoGameFullDto> Get(int gameId);
}

public class GetGameService(IVideoGameAccessor accessor) : IGetGameService
{
    private readonly IVideoGameAccessor _accessor = accessor;


    public async Task<VideoGameFullDto> Get(int gameId)
    {
        var response = await _accessor.Get(gameId);

        var result = new VideoGameFullDto
        {
            Id = response.Id,
            Title = response.Title,
            Platform = response.Platform,
            Developer = response.Developer,
            Publisher = response.Publisher,
        };
        
        return result;
    }
}