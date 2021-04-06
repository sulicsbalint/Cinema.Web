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
                .Include(s => s.Movie)
                .Include(s => s.Seats)
                .FirstOrDefault(m => m.Id == id);
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

        public List<Room> GetRooms()
        {
            return _context.Rooms
                .ToList();
        }

        public List<Seat> GetSeatsByScreeningId(int id)
        {
            return _context.Seats
                .Where(s => s.ScreeningId == id)
                .ToList();
        }

        public bool UpdateScreening(Screening screening)
        {
            try
            {
                _context.Update(screening);
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
