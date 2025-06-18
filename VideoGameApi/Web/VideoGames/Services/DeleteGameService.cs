using VideoGameApi.Core.Accessors;

namespace VideoGameApi.Web.VideoGames.Services;

public interface IDeleteGameService
{
    Task<bool> DeleteGame(int gameId);
}


public class DeleteGameService(IVideoGameAccessor accessor) : IDeleteGameService
{
    private readonly IVideoGameAccessor _accessor = accessor;

    public async Task<bool> DeleteGame(int gameId)
    {
        return await _accessor.Delete(gameId);
    }
}