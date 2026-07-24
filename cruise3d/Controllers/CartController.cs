using Microsoft.AspNetCore.Mvc;

namespace cruise3d.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCart() => Ok(new { items = new object[0] });

        [HttpPost("items")]
        public IActionResult AddItem([FromBody] object model) => Ok(new { message = "Not implemented" });

        [HttpPut("items/{id}")]
        public IActionResult UpdateItem(int id, [FromBody] object model) => NoContent();

        [HttpDelete("items/{id}")]
        public IActionResult RemoveItem(int id) => NoContent();
    }
}
