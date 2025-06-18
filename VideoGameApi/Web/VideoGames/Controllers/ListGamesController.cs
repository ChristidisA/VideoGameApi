using Microsoft.AspNetCore.Mvc;
using VideoGameApi.Data.Dtos;
using VideoGameApi.Web.VideoGames.Services;

namespace VideoGameApi.Web.VideoGames.Controllers;

[Tags("VideoGames")]
[ApiController]
[Route("api/[controller]")]
public class ListGamesController(IListGamesService service) : ControllerBase
{
    private readonly IListGamesService _service = service;
    
    [HttpGet]
    public async Task<List<VideoGameFullDto>> List([FromQuery] int page = 1, int pageSize = 10)
    {
        page = page < 1 ? 1 : page;
        pageSize = pageSize < 1 ? 10 : pageSize;
        
        var result = await _service.List(page, pageSize);
        return result;
    }
}