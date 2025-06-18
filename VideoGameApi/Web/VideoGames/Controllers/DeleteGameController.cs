using Microsoft.AspNetCore.Mvc;
using VideoGameApi.Web.VideoGames.Services;

namespace VideoGameApi.Web.VideoGames.Controllers;

[Tags("VideoGames")]
[ApiController]
[Route("api/[controller]")]
public class DeleteGameController(IDeleteGameService service) : ControllerBase
{
    private readonly IDeleteGameService _service = service;

    
    [HttpDelete("{gameId}")]
    public async Task<bool> Delete(int gameId)
    {
        return await _service.DeleteGame(gameId);
    }
}