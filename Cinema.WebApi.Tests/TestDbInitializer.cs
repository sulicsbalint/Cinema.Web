using Cinema.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.WebApi.Tests
{
    public class TestDbInitializer
    {
        public static void Initialize(CinemaDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Movies.Any()) return;

            List<Screening> tenetScreenings = new List<Screening>
            {
                new Screening
                {
                    Id = 1,
                    StartTime = DateTime.Now.AddDays(1),
                    Seats = new List<Seat>
                    {
                        new Seat
                        {
                            Id = 1,
                            Row = 1,
                            Column = 1,
                            Status = 0
                        },
                        new Seat
                        {
                            Id = 2,
                            Row = 1,
                            Column = 2,
                            Status = 0
                        },
                        new Seat
                        {
                            Id = 3,
                            Row = 1,
                            Column = 3,
                            Status = 0
                        }
                    }
                }
            };

            List<Screening> screenings1917 = new List<Screening>
            {
                new Screening
                {
                    Id = 2,
                    StartTime = DateTime.Now.AddDays(1),
                    Seats = new List<Seat>
                    {
                        new Seat
                        {
                            Id = 4,
                            Row = 1,
                            Column = 1,
                            Status = 0
                        },
                        new Seat
                        {
                            Id = 5,
                            Row = 1,
                            Column = 2,
                            Status = 0
                        },
                        new Seat
                        {
                            Id = 6,
                            Row = 1,
                            Column = 3,
                            Status = 0
                        }
                    }
                },
                new Screening
                {
                    Id = 3,
                    StartTime = DateTime.Now.AddDays(1),
                    Seats = new List<Seat>
                    {
                        new Seat
                        {
                            Id = 7,
                            Row = 1,
                            Column = 1,
                            Status = 0
                        },
                        new Seat
                        {
                            Id = 8,
                            Row = 1,
                            Column = 2,
                            Status = 0
                        },
                        new Seat
                        {
                            Id = 9,
                            Row = 1,
                            Column = 3,
                            Status = 0
                        }
                    }
                }
            };

            IList<Movie> defaultMovies = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Title = "Tenet",
                    Director = "Christopher Nolan",
                    Star = "John David Washington",
                    Duration = 150,
                    Description = "A legsikeresebb Batman-trilógia és az Eredet rendezője, Christopher Nolan ismét különlegesen egyedi, izgalmas és meghökkentő fordulatokban gazdag thrillert rendezett, amelyen egy angol kémnek kellene megmentenie a Földet a rá leselkedő és pusztulással fenyegető katasztrófától. Ám a szuperügynöknek nemcsak az idegen hatalmak embereivel, hanem a legnagyobb ellenséggel, az Idővel is meg kell küzdenie.",
                    Added = DateTime.Now,
                    Screenings = tenetScreenings
                },
                new Movie
                {
                    Id = 2,
                    Title = "1917",
                    Director = "Sam Mendes",
                    Star = "Dean-Charles Chapman",
                    Duration = 119,
                    Description = "Javában zajlik az I. világháború, amikor két fiatal brit katonát egy lehetetlennek tűnő küldetéssel bíznak meg: az ellenséges vonalon kell áthatolniuk, hogy egy üzenetet kézbesítsenek bajtársaiknak. Egy napjuk van, hogy célhoz érjenek, különben 1600 társuk, köztük egyikük testvére is odavész. A két bátor harcos hihetetlen elszántsággal indul neki a német frontnak…",
                    Added = DateTime.Now,
                    Screenings = screenings1917
                }
            };

            IList<Room> defaultRooms = new List<Room>
            {
                new Room
                {
                    Id = 1,
                    Name = "Terem 1",
                    Rows = 1,
                    Columns = 3,
                    Screenings = tenetScreenings
                },
                new Room
                {
                    Id = 2,
                    Name = "Terem 2",
                    Rows = 1,
                    Columns = 3,
                    Screenings = screenings1917
                }
            };

            context.AddRange(defaultMovies);
            context.AddRange(defaultRooms);
            context.SaveChanges();
        }
    }
}