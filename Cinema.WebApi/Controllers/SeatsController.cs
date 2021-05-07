using Cinema.Persistence;
using Cinema.Persistence.DTO;
using Cinema.Persistence.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        // PUT: api/Seats/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult PutSeat(int id, SeatDto seatDto)
        {
            if (id != seatDto.Id)
            {
                return BadRequest();
            }

            if (!seatDto.IsValid())
                return StatusCode(StatusCodes.Status406NotAcceptable);

            if (_service.UpdateSeat((Seat)seatDto))
                return Ok();
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
