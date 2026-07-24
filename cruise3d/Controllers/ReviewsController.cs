using Microsoft.AspNetCore.Mvc;

namespace cruise3d.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        [HttpGet("product/{productId}")]
        public IActionResult GetForProduct(int productId) => Ok(new object[0]);

        [HttpPost]
        public IActionResult Create([FromBody] object model) => Created("", model);

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => NoContent();
    }
}
