using Cinema.Web.Models;
using System.Collections.Generic;

namespace Cinema.Web.Services
{
    public interface ICinemaService
    {
        List<Movie> GetMovies(string title = null);
        Movie GetMovieById(int id);
        List<Screening> GetScreenings();
        Screening GetScreeningById(int id);
        List<Screening> GetTodaysScreenings();
        List<Screening> GetScreeningsByMovieId(int id);
        List<Room> GetRooms();
        List<Seat> GetSeatsByScreeningId(int id);
        bool UpdateScreening(Screening screening);
        bool UpdateSeats(List<Seat> seats);
    }
}