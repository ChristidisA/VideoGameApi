using Microsoft.EntityFrameworkCore;
using VideoGameApi.Data;
using VideoGameApi.Data.Dtos;

namespace VideoGameApi.Core;

public class VideoGameRepository : VideoGameAccessor
{
    private readonly VideoGameDbContext  _context;

    public VideoGameRepository(VideoGameDbContext  context)
    {
        _context = context;
    }

    public async Task<VideoGame> Add(AddVideoGameDto newGame)
    {
        var result = new VideoGame
        {
            Title = newGame.Title,
            Platform = newGame.Platform,
            Developer = newGame.Developer,
            Publisher = newGame.Publisher,
        };
        
        await _context.VideoGames.AddAsync(result);
        await _context.SaveChangesAsync();
        return result;
    }
}