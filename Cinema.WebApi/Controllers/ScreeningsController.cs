using System;
using System.Collections.Generic;
using Cinema.Persistence.DTO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Cinema.Persistence.Services;
using Microsoft.AspNetCore.Http;
using Cinema.Persistence;
using Microsoft.AspNetCore.Authorization;

namespace Cinema.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreeningsController : ControllerBase
    {
        private readonly ICinemaService _service;

        public ScreeningsController(ICinemaService service)
        {
            _service = service;
        }

        // GET: api/Screenings/Movie/5
        [HttpGet("Movie/{movieId}")]
        public ActionResult<IEnumerable<ScreeningDto>> GetScreenings(int movieId)
        {
            try
            {
                return _service
                    .GetMovieById(movieId)
                    .Screenings.Select(screening => (ScreeningDto)screening).ToList();
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        // GET: api/Screenings/5
        [HttpGet("{id}")]
        public ActionResult<ScreeningDto> GetScreening(int id)
        {
            try
            {
                return (ScreeningDto)_service.GetScreeningById(id);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // PUT: api/Screenings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult PutScreening(int id, ScreeningDto screening)
        {
            if (id != screening.Id)
            {
                return BadRequest();
            }

            if (_service.UpdateScreening((Screening)screening))
                return Ok();
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        // POST: api/Screenings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPost]
        public ActionResult<ScreeningDto> PostScreening(ScreeningDto screeningDto)
        {
            var screening = _service.CreateScreening((Screening)screeningDto);
            if (screening == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            else
            {
                return CreatedAtAction("GetScreening", new { id = screening.Id }, (ScreeningDto)screening);
            }
        }

        // DELETE: api/Screenings/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteScreening(int id)
        {
            if (_service.DeleteScreening(id))
                return Ok();
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
