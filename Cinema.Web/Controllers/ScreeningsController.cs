using Microsoft.AspNetCore.Mvc;
using Cinema.Persistence;
using Cinema.Persistence.Services;
using System.Collections.Generic;
using System;

namespace Cinema.Web.Controllers
{
    public class ScreeningsController : Controller
    {
        private readonly ICinemaService _service;

        public ScreeningsController(ICinemaService service)
        {
            _service = service;
        }

        // GET: Screenings
        public IActionResult Index()
        {
            var screenings = _service.GetScreenings();
            if (screenings == null) return NotFound();

            return View(screenings);
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
            seats.StartTime = screening.StartTime;

            return View(seats);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reserve(int id, int rows, int cols, string rname, DateTime time, BookViewModel vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            List<Seat> seats = new List<Seat>();
            List<Seat> vmSeats = _service.GetSeatsByScreeningId(id).Seats;
            int ctr = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    var tmp = "id" + i + j;
                    if (Request.Form[tmp].Count == 2 && vmSeats[i*cols+j].Status != 1)
                    {
                        ctr++;
                        vmSeats[i * cols + j].ReserverName = Request.Form["Name"];
                        vmSeats[i * cols + j].ReserverPhone = Request.Form["Phone"];
                        vmSeats[i * cols + j].Status = 1;
                        seats.Add(vmSeats[i * cols + j]);
                    }
                }
            }

            if (ModelState.IsValid && ctr != 0)
            {
                _service.UpdateSeats(seats);
                return RedirectToAction("Index", "Home");
            }

            vm.Id = id;
            vm.Rows = rows;
            vm.Columns = cols;
            vm.Seats = vmSeats;
            vm.StartTime = time;
            vm.RoomName = rname;
            vm.NoSeat = true;

            return View(vm);
        }
    }
}
