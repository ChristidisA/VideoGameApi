using Microsoft.AspNetCore.Mvc;
using VideoGameApi.Data.Dtos;
using VideoGameApi.Web.VideoGames.Services;

namespace VideoGameApi.Web.VideoGames.Controllers;

[Tags("VideoGames")]
[ApiController]
[Route("api/[controller]")]
public class UpdateGameController(IUpdateGameService service) : ControllerBase
{
    private readonly IUpdateGameService _service = service;
    
    [HttpPut(template: "{listingId}")]
    public async Task<VideoGameFullDto> Update(int listingId, [FromBody] UpdateVideoGameDto updatedGame)
    {
        var result = await _service.Update(listingId, updatedGame);
        return result;
    }
}