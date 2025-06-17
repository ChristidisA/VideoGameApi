using VideoGameApi.Data.Dtos;
using VideoGameApi.Data.Models;

namespace VideoGameApi.Core.Accessors;

public interface VideoGameAccessor
{
    Task<VideoGame> Add(AddVideoGameDto newGame);
    
    // Task<VideoGame> Update(int videoGameId, UpdateVideoGameDto updatedGame);
    //
    // Task<bool> Delete(int videoGameId);
    //
    // Task<VideoGame> Get(int videoGameId);
    //
    Task<List<VideoGame>> List(int page, int pageSize);
}