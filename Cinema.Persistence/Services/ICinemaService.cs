using System.Collections.Generic;

namespace Cinema.Persistence.Services
{
    public interface ICinemaService
    {
        //Movie
        List<Movie> GetMovies(string title = null);
        Movie GetMovieById(int id);
        Movie CreateMovie(Movie movie);
        bool UpdateMovie(Movie movie);
        bool DeleteMovie(int id);

        //Room
        List<Room> GetRooms();

        //Screening
        List<Screening> GetScreenings();
        Screening GetScreeningById(int id);
        List<Screening> GetTodaysScreenings();
        List<Screening> GetScreeningsByMovieId(int id);
        Screening CreateScreening(Screening screening);
        bool UpdateScreening(Screening screening);
        bool DeleteScreening(int id);

        //Seat
        List<Seat> GetSeats();
        BookViewModel GetSeatsByScreeningId(int id);
        bool UpdateSeat(Seat seat);
        bool UpdateSeats(List<Seat> seats);
    }
}