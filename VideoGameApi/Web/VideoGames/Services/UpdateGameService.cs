using VideoGameApi.Core.Accessors;
using VideoGameApi.Data.Dtos;

namespace VideoGameApi.Web.VideoGames.Services;

public interface IUpdateGameService
{
    Task<VideoGameFullDto> Update(int listingId, UpdateVideoGameDto updatedDto);
}

public class UpdateGameService(IVideoGameAccessor accessor) : IUpdateGameService
{
    private readonly IVideoGameAccessor _accessor =  accessor;
    public async Task<VideoGameFullDto> Update(int listingId, UpdateVideoGameDto updatedDto)
    {
        var response = await _accessor.Update(listingId, updatedDto);

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