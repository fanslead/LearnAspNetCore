using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnRoute.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index(string? id)
        {
            return Ok(new { id });
        }
    }
}
