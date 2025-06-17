using Microsoft.EntityFrameworkCore;
using VideoGameApi.Core.Accessors;
using VideoGameApi.Data.DataBase;
using VideoGameApi.Data.Dtos;
using VideoGameApi.Data.Models;

namespace VideoGameApi.Core.Repositories;

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

    public async Task<List<VideoGame>> List(int page, int pageSize)
    {
        var result = await _context.VideoGames
            .Skip(pageSize* (page - 1 ))
            .Take(pageSize)
            .ToListAsync();
        
        return result;
    }
}