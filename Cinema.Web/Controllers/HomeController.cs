using Cinema.Web.Models;
using Cinema.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cinema.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICinemaService _service;

        public HomeController(ICinemaService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var movies = _service.GetMovies();
            var screenings = _service.GetScreenings();
            var today = _service.GetTodaysScreenings();
            if (movies == null || screenings == null || today == null) return NotFound();

            ViewBag.Movies = movies;
            ViewBag.Screenings = screenings;
            ViewBag.Today = today;

            return View(movies);
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
