using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPITutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login()
        {
            return Created("", new JwtTokenGenerator().GenerateToken());
        }
    }
}
