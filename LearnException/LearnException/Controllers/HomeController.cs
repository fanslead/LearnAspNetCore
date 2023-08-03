using LearnException.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LearnException.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Throw()
        {
            throw new Exception("Customer Excetion");
        }
        public IActionResult FileNotFound()
        {
            throw new FileNotFoundException();
        }
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Filter()
        {
            throw new Exception("MyExceptionFilter Excetion");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}