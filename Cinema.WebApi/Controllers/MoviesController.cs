using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Cinema.Persistence.Services;
using Cinema.Persistence.DTO;
using System.Linq;
using Cinema.Persistence;
using Microsoft.AspNetCore.Http;
using System;

namespace Cinema.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ICinemaService _service;

        public MoviesController(ICinemaService service)
        {
            _service = service;
        }

        // GET: api/Movies
        [HttpGet]
        public ActionResult<IEnumerable<MovieDto>> GetMovies()
        {
            return _service.GetMovies().Select(movie => (MovieDto)movie).ToList();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public ActionResult<MovieDto> GetMovie(int id)
        {
            try
            {
                return (MovieDto)_service.GetMovieById(id);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutMovie(int id, MovieDto movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            if (_service.UpdateMovie((Movie)movie)) 
                return Ok();
            else 
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        // POST: api/Movies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<MovieDto> PostMovie(MovieDto movieDto)
        {
            var movie = _service.CreateMovie((Movie)movieDto);
            if (movie == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            else
            {
                return CreatedAtAction("GetMovie", new { id = movie.Id }, (MovieDto)movie);
            }
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            if (_service.DeleteMovie(id))
                return Ok();
            else 
                return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
