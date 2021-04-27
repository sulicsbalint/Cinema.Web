using Cinema.Persistence;
using System.Collections.Generic;

namespace Cinema.Persistence.Services
{
    public interface ICinemaService
    {
        List<Movie> GetMovies(string title = null);
        Movie GetMovieById(int id);
        List<Screening> GetScreenings();
        Screening GetScreeningById(int id);
        List<Screening> GetTodaysScreenings();
        List<Screening> GetScreeningsByMovieId(int id);
        BookViewModel GetSeatsByScreeningId(int id);
        bool UpdateSeats(List<Seat> seats);
    }
}