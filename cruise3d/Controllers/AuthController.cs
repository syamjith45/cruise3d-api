using Microsoft.AspNetCore.Mvc;

namespace cruise3d.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] object model)
        {
            return Ok(new { message = "Not implemented" });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] object model)
        {
            return Ok(new { message = "Not implemented" });
        }
    }
}
