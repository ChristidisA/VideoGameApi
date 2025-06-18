using Microsoft.AspNetCore.Mvc;
using VideoGameApi.Data.Dtos;
using VideoGameApi.Web.VideoGames.Services;

namespace VideoGameApi.Web.VideoGames.Controllers;

[Tags("VideoGames")]
[ApiController]
[Route("api/[controller]")]
public class GetGameController(IGetGameService service) : ControllerBase
{
    private readonly IGetGameService _service = service;

    [HttpGet("{listingId}")]
    public async Task<VideoGameFullDto> Get(int listingId)
    {
        return await _service.Get(listingId);
    }
}