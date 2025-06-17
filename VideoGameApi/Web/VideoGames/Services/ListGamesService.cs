using VideoGameApi.Core;
using VideoGameApi.Core.Accessors;
using VideoGameApi.Data.Dtos;

namespace VideoGameApi.Web.VideoGames.Services;

public interface IListGamesService
{
    Task<List<VideoGameFullDto>> List(int page, int pageSize);
}

public class ListGamesService  : IListGamesService
{
    private readonly VideoGameAccessor _accessor;

    public ListGamesService(VideoGameAccessor accessor)
    {
        _accessor = accessor;
    }

    public async Task<List<VideoGameFullDto>> List(int page, int pageSize)
    {
        var response = await _accessor.List(page, pageSize);

        var result = response.Select(r => new VideoGameFullDto
        {
            Id = r.Id,
            Title = r.Title,
            Platform = r.Platform,
            Developer = r.Developer,
            Publisher = r.Publisher,
        })
        .ToList();
        
        return result;
    }
}