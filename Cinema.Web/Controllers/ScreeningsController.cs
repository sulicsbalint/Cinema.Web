using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinema.Web.Models;
using Cinema.Web.Services;
using System.Collections.Generic;
using System.Diagnostics;

namespace Cinema.Web.Controllers
{
    public class ScreeningsController : Controller
    {
        private readonly CinemaDbContext _context;
        private readonly ICinemaService _service;

        public ScreeningsController(CinemaDbContext context, ICinemaService service)
        {
            _service = service;
            _context = context;
        }

        // GET: Screenings
        public IActionResult Index()
        {
            var cinemaDbContext = _context.Screenings.Include(s => s.Movie).Include(s => s.Room);
            return View(cinemaDbContext.ToList());
        }

        // GET: Screenings/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var screening = _context.Screenings
                .Include(s => s.Movie)
                .Include(s => s.Room)
                .Include(s => s.Seats)
                .FirstOrDefault(m => m.Id == id);
            if (screening == null)
            {
                return NotFound();
            }

            return View(screening);
        }

        public IActionResult Reserve(int? id)
        {
            if (id == null) return NotFound();

            var screening = _service.GetScreeningById((int)id);
            var seats = _service.GetSeatsByScreeningId((int)id);
            if (seats == null || screening == null) return NotFound();

            seats.Id = (int)id;
            seats.RoomName = screening.Room.Name;
            seats.Rows = screening.Room.Rows;
            seats.Columns = screening.Room.Columns;

            return View(seats);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reserve(int id, int rows, int cols, BookViewModel vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            List<Seat> seats = new List<Seat>();
            List<Seat> vmSeats = _service.GetSeatsByScreeningId(id).Seats;
            for (int i = 0; i < rows*cols; i++)
            {
                var tmp = "id" + i;
                if (Request.Form[tmp].Count == 2 && vmSeats[i].Status != 1)
                {
                    vmSeats[i].ReserverName = Request.Form["Name"];
                    vmSeats[i].ReserverPhone = Request.Form["Phone"];
                    vmSeats[i].Status = 1;
                    seats.Add(vmSeats[i]);
                }
            }

            if (ModelState.IsValid)
            {
                _service.UpdateSeats(seats);
                return RedirectToAction("Index", "Screenings");
            }

            return View(vm.Seats);
        }
    }
}
