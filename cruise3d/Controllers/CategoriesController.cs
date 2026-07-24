using Microsoft.AspNetCore.Mvc;

namespace cruise3d.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll() => Ok(new object[0]);

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(new { id });

        [HttpPost]
        public IActionResult Create([FromBody] object model) => CreatedAtAction(nameof(Get), new { id = 0 }, model);

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] object model) => NoContent();

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => NoContent();
    }
}
