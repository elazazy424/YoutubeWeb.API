using Microsoft.AspNetCore.Mvc;
using YoutubeWeb.API.Errors;
using YoutubeWeb.BLL.Interfaces;

namespace YoutubeWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YoutubeController : ControllerBase
    {
        private readonly IYoutubeClientRepository _youtubeClientRepository;

        public YoutubeController(IYoutubeClientRepository youtubeClientRepository)
        {
            _youtubeClientRepository = youtubeClientRepository;
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery]string query, [FromQuery] int maxResult = 50)
        {
            var result = await _youtubeClientRepository.SearchAsync(query, maxResult);
            if (result == null)
            {
                return NotFound(new ApiResponse(400));
            }
            return Ok(result);
        }
        [HttpGet("channel/{id}")]
        public async Task<IActionResult> SearchChannel([FromRoute] string id, [FromQuery] int maxResult = 50)
        {
            var result = await _youtubeClientRepository.SearchChannelAsync(id, maxResult);
            if (result == null)
            {
                return NotFound(new ApiResponse(400));
            }
            return Ok(result);
        }
    }
}
