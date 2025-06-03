using VideoGameApi.Core;
using VideoGameApi.Data.Dtos;

namespace VideoGameApi.Web.Services;

public interface IAddGameService
{
    Task<VideoGameFullDto> Add(AddVideoGameDto newGame);
}

public class AddGameService : IAddGameService
{
    private readonly VideoGameAccessor _accessor;

    public AddGameService(VideoGameAccessor accessor)
    {
        _accessor = accessor;
    }

    public async Task<VideoGameFullDto> Add(AddVideoGameDto newGame)
    {
        var response = await _accessor.Add(newGame);

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