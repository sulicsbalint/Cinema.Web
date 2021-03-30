using Cinema.Web.Models;
using System.Collections.Generic;

namespace Cinema.Web.Services
{
    public interface ICinemaService
    {
        public List<Movie> GetMovies(string title = null);
        public Movie GetMovieById(int id);
        public List<Screening> GetScreenings();
        public List<Screening> GetTodaysScreenings();
        public List<Screening> GetScreeningsByMovieId(int id);
    }
}
