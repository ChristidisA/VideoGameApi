using Microsoft.AspNetCore.Mvc;
using VideoGameApi.Data.Dtos;
using VideoGameApi.Web.VideoGames.Services;

namespace VideoGameApi.Web.VideoGames.Controllers;

[Tags("VideoGames")]
[ApiController]
[Route("api/[controller]")]
public class AddGameController : ControllerBase
{
    private readonly IAddGameService _service;

    public AddGameController(IAddGameService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<VideoGameFullDto> Add([FromBody] AddVideoGameDto newGame)
    {
        var response = await _service.Add(newGame);
        
        return response;
    }
}