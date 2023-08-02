using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnRoute.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            return Ok(new { id });
        }
        [HttpGet("GetId/{id:int:min(1)}")]
        public IActionResult GetIdTow(int id)
        {
            return Ok(new { id });
        }
    }
}
