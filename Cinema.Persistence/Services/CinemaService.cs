using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Persistence.Services
{
    public class CinemaService : ICinemaService
    {
        #region Fields

        public readonly CinemaDbContext _context;

        #endregion

        #region Constructor

        public CinemaService(CinemaDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Movie services

        public List<Movie> GetMovies(string title = null)
        {
            return _context.Movies
                .Where(m => m.Title.Contains(title ?? ""))
                .OrderByDescending(m => m.Added)
                .ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies
                .Include(m => m.Screenings)
                .FirstOrDefault(m => m.Id == id);
        }

        public Movie CreateMovie(Movie movie)
        {
            try
            {
                movie.Added = DateTime.Now;
                _context.Add(movie);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
            catch (DbUpdateException)
            {
                return null;
            }

            return movie;
        }

        public bool UpdateMovie(Movie movie)
        {
            try
            {
                _context.Update(movie);
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

        public bool DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return false;
            }

            try
            {
                _context.Remove(movie);
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

        #endregion

        #region Screening services

        public List<Screening> GetScreenings()
        {
            return _context.Screenings
                .Include(s => s.Movie)
                .Include(s => s.Room)
                .Include(s => s.Seats)
                .OrderBy(s => s.StartTime)
                .ToList();
        }

        public Screening GetScreeningById(int id)
        {
            return _context.Screenings
                .Include(s => s.Room)
                .Include(s => s.Seats)
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

        public Screening CreateScreening(Screening screening)
        {
            try
            {
                if (IsTimeFree(screening))
                {
                    screening.Seats = CreateSeats();
                    _context.Add(screening);
                    _context.SaveChanges();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
            catch (DbUpdateException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }

            return screening;
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

        public bool DeleteScreening(int id)
        {
            var screening = _context.Screenings.Find(id);
            if (screening == null)
            {
                return false;
            }

            try
            {
                _context.Remove(screening);
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

        private bool IsTimeFree(Screening screening)
        {
            foreach (var item in _context.Screenings)
            {
                var itemDur = _context.Movies
                .FirstOrDefault(m => m.Id == item.MovieId)
                .Duration + 15;
                var itemTime = item.StartTime;
                var itemInterval = itemTime.AddMinutes(itemDur);

                var screeningDur = (_context.Movies
                .FirstOrDefault(m => m.Id == screening.MovieId)
                .Duration + 15) * (-1);
                var screeningTime = screening.StartTime;
                var screeningInterval = itemTime.AddMinutes(screeningDur);

                if (screening.StartTime < itemInterval && screening.StartTime > screeningInterval)
                {
                    throw new Exception();
                }
            }

            return true;
        }

        #endregion

        #region Seat services

        public bool UpdateSeat(Seat seat)
        {
            try
            {
                _context.Update(seat);
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

        private List<Seat> CreateSeats()
        {
            var seats = new List<Seat>
            {
                new Seat
                {
                    Row = 1,
                    Column = 1,
                    Status = 0
                },
                new Seat
                {
                    Row = 1,
                    Column = 2,
                    Status = 0
                },
                new Seat
                {
                    Row = 1,
                    Column = 3,
                    Status = 0
                },
                new Seat
                {
                    Row = 1,
                    Column = 4,
                    Status = 0
                },
                new Seat
                {
                    Row = 1,
                    Column = 5,
                    Status = 0
                },
                new Seat
                {
                    Row = 1,
                    Column = 6,
                    Status = 0
                },
                new Seat
                {
                    Row = 2,
                    Column = 1,
                    Status = 0
                },
                new Seat
                {
                    Row = 2,
                    Column = 2,
                    Status = 0
                },
                new Seat
                {
                    Row = 2,
                    Column = 3,
                    Status = 0
                },
                new Seat
                {
                    Row = 2,
                    Column = 4,
                    Status = 0
                },
                new Seat
                {
                    Row = 2,
                    Column = 5,
                    Status = 0
                },
                new Seat
                {
                    Row = 2,
                    Column = 6,
                    Status = 0
                },
                new Seat
                {
                    Row = 3,
                    Column = 1,
                    Status = 0
                },
                new Seat
                {
                    Row = 3,
                    Column = 2,
                    Status = 0
                },
                new Seat
                {
                    Row = 3,
                    Column = 3,
                    Status = 0
                },
                new Seat
                {
                    Row = 3,
                    Column = 4,
                    Status = 0
                },
                new Seat
                {
                    Row = 3,
                    Column = 5,
                    Status = 0
                },
                new Seat
                {
                    Row = 3,
                    Column = 6,
                    Status = 0
                }
            };

            return seats;
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

        public List<Seat> GetSeats()
        {
            return _context.Seats
                .Include(s => s.Screening)
                .ToList();
        }

        #endregion

        #region Room services

        public List<Room> GetRooms()
        {
            return _context.Rooms
                .ToList();
        }

        #endregion
    }
}
