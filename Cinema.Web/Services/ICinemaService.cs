using Cinema.Web.Models;
using System.Collections.Generic;

namespace Cinema.Web.Services
{
    public interface ICinemaService
    {
        List<Movie> GetMovies(string title = null);
        Movie GetMovieById(int id);
        List<Screening> GetScreenings();
        List<Screening> GetTodaysScreenings();
        List<Screening> GetScreeningsByMovieId(int id);
        BookViewModel GetSeatsByScreeningId(int id);
        bool UpdateSeats(List<Seat> seats);
    }
}