using Cinema.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

        public List<Screening> GetScreenings()
        {
            return _context.Screenings
                .Include(s => s.Movie)
                .Include(s => s.Room)
                .OrderBy(s => s.StartTime)
                .ToList();
        }

        public Screening GetScreeningById(int id)
        {
            return _context.Screenings
                .Include(s => s.Room)
                .FirstOrDefault(s => s.Id == id);
        }

        public List<Screening> GetTodaysScreenings()
        {
            return _context.Screenings
                .Where(s => s.StartTime.Date.Equals(DateTime.Now.Date))
                .ToList();
        }

        public List<Screening> GetScreeningsByMovieId(int id)
        {
            return _context.Screenings
                .Where(s => s.MovieId == id)
                .OrderBy(s => s.StartTime)
                .ToList();
        }

        public BookViewModel GetSeatsByScreeningId(int id)
        {
            var screening = _context.Screenings
                .Include(s => s.Room)
                .FirstOrDefault(s => s.Id == id);

            BookViewModel vm = new BookViewModel
            {
                Seats = _context.Seats
                    .Where(s => s.ScreeningId == id)
                    .ToList(),
                Rows = screening.Room.Rows,
                Columns = screening.Room.Columns
            };

            return vm;
        }

        public bool UpdateSeats(List<Seat> seats)
        {
            try
            {
                _context.UpdateRange(seats);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }
    }
}
