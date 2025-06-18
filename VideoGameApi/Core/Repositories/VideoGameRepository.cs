using Microsoft.EntityFrameworkCore;
using VideoGameApi.Core.Accessors;
using VideoGameApi.Data.DataBase;
using VideoGameApi.Data.Dtos;
using VideoGameApi.Data.Models;

namespace VideoGameApi.Core.Repositories;

public class VideoGameRepository(VideoGameDbContext context) : IVideoGameAccessor
{
    private readonly VideoGameDbContext _context = context;   
    
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

    public async Task<VideoGame> Update(int videoGameId, UpdateVideoGameDto updatedGame)
    {
        var response = await _context.VideoGames.FindAsync(videoGameId);
        
        if (response == null)
        {
            throw new Exception("VideoGame not found");
        }

        response.Title = updatedGame.Title ?? response.Title;
        response.Platform = updatedGame.Platform ?? response.Platform;
        response.Developer = updatedGame.Developer ?? response.Developer;
        response.Publisher = updatedGame.Publisher ?? response.Publisher;
        
        _context.VideoGames.Update(response);
        await _context.SaveChangesAsync();
        return response;
    }

    public async Task<bool> Delete(int gameId)
    {
        var response = await _context.VideoGames.FindAsync(gameId);

        if (response == null)
        {
            return false;
        }
        
        _context.VideoGames.Remove(response);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<VideoGame> Get(int gameId)
    {
        var  response = await _context.VideoGames.FindAsync(gameId);

        if (response == null)
        {
           throw new Exception("VideoGame not found"); 
        }
        
        return response;
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