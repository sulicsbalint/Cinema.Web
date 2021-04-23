using Microsoft.EntityFrameworkCore;

namespace Cinema.Persistence
{
    public class CinemaDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public CinemaDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
