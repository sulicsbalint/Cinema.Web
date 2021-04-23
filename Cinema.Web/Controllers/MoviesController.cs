using Microsoft.AspNetCore.Mvc;
using Cinema.Persistence.Services;

namespace Cinema.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ICinemaService _service;

        public MoviesController(ICinemaService service)
        {
            _service = service;
        }

        // GET: Movies
        public IActionResult Index()
        {
            var movies = _service.GetMovies();
            if (movies == null) return NotFound();

            return View(movies);
        }

        // GET: Movies/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var movie = _service.GetMovieById((int)id);
            var screenings = _service.GetScreeningsByMovieId((int)id);
            if (movie == null || screenings == null) return NotFound();

            ViewBag.Movie = movie;
            ViewBag.Screenings = screenings;
            return View();
        }

        public IActionResult DisplayImage(int id)
        {
            var movie = _service.GetMovieById(id);
            if (movie == null) return null;

            return base.File(movie.Image, "image/jpg");
        }

        public IActionResult DisplayCover(int id)
        {
            var movie = _service.GetMovieById(id);
            if (movie == null) return null;

            return base.File(movie.Cover, "image/jpg");
        }
    }
}
