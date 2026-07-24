using Microsoft.AspNetCore.Mvc;

namespace cruise3d.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll() => Ok(new object[0]);

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(new { id });

        [HttpPost]
        public IActionResult Create([FromBody] object model) => CreatedAtAction(nameof(Get), new { id = 0 }, model);
    }
}
