using Cinema.Web.Models;
using Cinema.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Cinema.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICinemaService _service;

        public HomeController(ILogger<HomeController> logger, ICinemaService service)
        {
            _service = service;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Movies = _service.GetMovies();
            ViewBag.Screenings = _service.GetScreenings();
            ViewBag.Today = _service.GetTodaysScreenings();
            return View(_service.GetMovies());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
