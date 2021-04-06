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
            if (id == null)
            {
                return NotFound();
            }

            var seats = _service.GetSeatsByScreeningId((int)id);

            if (seats == null)
            {
                return NotFound();
            }

            ViewBag.Screenings = new SelectList(_service.GetScreenings(), "Id", "StartTime", seats[0].ScreeningId);
            return View(seats);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reserve(int id, List<SeatViewModel> vm)
        {
            Debug.WriteLine("Screening id: " + id + " ViewModelHossza: " + vm.Count);
            if (id != vm.ElementAt(0).ScreeningId)
            {
                return NotFound();
            }

            List<Seat> seats = new List<Seat>();
            
            foreach (Seat item in vm)
            {
                seats.Add((Seat)item);
            }

            if (ModelState.IsValid)
            {
                _service.UpdateSeats(seats);
                return RedirectToAction("Index", "Screenings");
            }

            ViewBag.Screenings = new SelectList(_service.GetScreenings(), "Id", "StartTime", vm[0].ScreeningId);
            return View(seats);
        }

        // GET: Screenings/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Description");
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name");
            return View();
        }

        // POST: Screenings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovieId,StartTime,RoomId")] Screening screening)
        {
            if (ModelState.IsValid)
            {
                _context.Add(screening);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Description", screening.MovieId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", screening.RoomId);
            return View(screening);
        }

        // GET: Screenings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var screening = await _context.Screenings.FindAsync(id);
            if (screening == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Description", screening.MovieId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", screening.RoomId);
            return View(screening);
        }

        // POST: Screenings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovieId,StartTime,RoomId")] Screening screening)
        {
            if (id != screening.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(screening);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScreeningExists(screening.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Description", screening.MovieId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", screening.RoomId);
            return View(screening);
        }

        // GET: Screenings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var screening = await _context.Screenings
                .Include(s => s.Movie)
                .Include(s => s.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (screening == null)
            {
                return NotFound();
            }

            return View(screening);
        }

        // POST: Screenings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var screening = await _context.Screenings.FindAsync(id);
            _context.Screenings.Remove(screening);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScreeningExists(int id)
        {
            return _context.Screenings.Any(e => e.Id == id);
        }
    }
}
