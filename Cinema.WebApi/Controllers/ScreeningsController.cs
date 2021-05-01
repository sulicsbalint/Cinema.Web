using System;
using System.Collections.Generic;
using Cinema.Persistence.DTO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Cinema.Persistence.Services;

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

        // GET: api/Screenings/5
        [HttpGet("{movieId}")]
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

        /*// GET: api/Screenings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Screening>> GetScreening(int id)
        {
            var screening = await _context.Screenings.FindAsync(id);

            if (screening == null)
            {
                return NotFound();
            }

            return screening;
        }

        // PUT: api/Screenings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScreening(int id, Screening screening)
        {
            if (id != screening.Id)
            {
                return BadRequest();
            }

            _context.Entry(screening).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScreeningExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Screenings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Screening>> PostScreening(Screening screening)
        {
            _context.Screenings.Add(screening);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScreening", new { id = screening.Id }, screening);
        }

        // DELETE: api/Screenings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Screening>> DeleteScreening(int id)
        {
            var screening = await _context.Screenings.FindAsync(id);
            if (screening == null)
            {
                return NotFound();
            }

            _context.Screenings.Remove(screening);
            await _context.SaveChangesAsync();

            return screening;
        }

        private bool ScreeningExists(int id)
        {
            return _context.Screenings.Any(e => e.Id == id);
        }*/
    }
}
