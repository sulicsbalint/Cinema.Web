using Cinema.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Web.Services
{
    public class CinemaService : ICinemaService
    {
        public readonly CinemaDbContext _context;

        public CinemaService(CinemaDbContext context)
        {
            _context = context;
        }

        public List<Movie> GetMovies(string title = null)
        {
            return _context.Movies
                .Where(m => m.Title.Contains(title ?? ""))
                .OrderBy(m => m.Added)
                .ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies
                .FirstOrDefault(m => m.Id == id);
        }

        /*public List<Screening> GetScreeningsByMovieId(int id)
        {
            return _context.Screenings
                .Where(s => s.Id == id)
                .ToList();
        }

        public void AddMovie(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException();
            }

            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void AddScreening(Screening screening)
        {
            if (screening == null)
                throw new ArgumentNullException();

            _context.Screenings.Add(screening);
            _context.SaveChanges();
        }

        public void RemoveMovieByName(string title, int id)
        {
            Movie movie = _context.Movies
                .Where(m => m.Id == id)
                .FirstOrDefault(m => m.Title == title);

            if (movie == null)
                return;

            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }*/
    }
}
