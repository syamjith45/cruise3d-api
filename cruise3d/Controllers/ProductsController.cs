using Microsoft.AspNetCore.Mvc;

namespace cruise3d.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new object[0]);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new { id });
        }

        [HttpPost]
        public IActionResult Create([FromBody] object model)
        {
            return CreatedAtAction(nameof(Get), new { id = 0 }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] object model)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
