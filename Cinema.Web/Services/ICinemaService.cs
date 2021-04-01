using Cinema.Web.Models;
using System.Collections.Generic;

namespace Cinema.Web.Services
{
    public interface ICinemaService
    {
        public List<Movie> GetMovies(string title = null);
        public Movie GetMovieById(int id);
        public List<Screening> GetScreenings();
        /*public Screening GetScreeningById(int id);*/
        public List<Screening> GetTodaysScreenings();
        public List<Screening> GetScreeningsByMovieId(int id);
        /*public Room GetRoomByScreeningId(int id);
        public bool UpdateScreening(Screening screening);
        public bool UpdateSeats(List<Seat> seats);
        public bool UpdateRoom(Room room);*/
    }
}