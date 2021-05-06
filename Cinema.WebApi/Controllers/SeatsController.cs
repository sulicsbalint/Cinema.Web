using Cinema.Persistence.DTO;
using Cinema.Persistence.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly ICinemaService _service;

        public SeatsController(ICinemaService service)
        {
            _service = service;
        }

        // GET: api/Seats/Screening/5
        [HttpGet("Screening/{screeningId}")]
        public ActionResult<IEnumerable<SeatDto>> GetSeats(int screeningId)
        {
            try
            {
                return _service
                    .GetScreeningById(screeningId)
                    .Seats.Select(seat => (SeatDto)seat).ToList();
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        // GET: api/Seats
        [HttpGet]
        public ActionResult<IEnumerable<SeatDto>> GetSeats()
        {
            return _service.GetSeats()
                .Select(seat => (SeatDto)seat)
                .ToList();
        }
    }
}
