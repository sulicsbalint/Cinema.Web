using Cinema.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                .OrderBy(s => s.StartTime)
                .ToList();
        }

        /*public Screening GetScreeningById(int id)
        {
            return _context.Screenings
                .Include(s => s.Rooms)
                .Include(s => s.Movie)
                .FirstOrDefault(m => m.Id == id);
        }*/

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

        /*public Room GetRoomByScreeningId(int id)
        {
            return _context.Rooms
                .Include(r => r.Seats)
                .Include(r => r.Screening)
                .Include(r => r.Screening.Movie)
                .FirstOrDefault(r => r.ScreeningId == id);
        }

        public bool UpdateScreening(Screening screening)
        {
            try
            {
                _context.Update(screening);
                foreach (Room item in screening.Rooms)
                {
                    _context.Update(item.Seats);
                }
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
                foreach (var item in seats)
                {
                    var seat = _context.Seats
                        .Where(s => s.Id == item.Id)
                        .FirstOrDefault();
                    Debug.WriteLine(item.Status);
                    seat.Status = item.Status;
                    _context.Update(seat);
                }
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }

        public bool UpdateRoom(Room room)
        {
            try
            {
                _context.Update(room);
                //foreach (var item in room.Seats)
                //{
                //    var seat = _context.Seats
                //        .Where(s => s.Id == item.Id)
                //        .FirstOrDefault();
                //    _context.Update(seat);
                //}
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }*/
    }
}
