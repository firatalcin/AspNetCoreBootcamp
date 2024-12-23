using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvertoryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
