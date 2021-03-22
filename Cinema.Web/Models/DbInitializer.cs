using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cinema.Web.Models
{
    public static class DbInitializer
    {
        public static void Initialize(CinemaDbContext context, string imageDirectory)
        {
            context.Database.Migrate();

            if (context.Movies.Any())
                return;

            var tenetPath = Path.Combine(imageDirectory, "tenet.jpg");
            var path1917 = Path.Combine(imageDirectory, "1917.jpg");
            var rushPath = Path.Combine(imageDirectory, "rush.jpg");
            var vicePath = Path.Combine(imageDirectory, "vice.jpg");
            var johnPath = Path.Combine(imageDirectory, "john_wick.jpg");
            var cherryPath = Path.Combine(imageDirectory, "cherry.jpg");

            var tenetCover = Path.Combine(imageDirectory, "tenet_cover.jpg");
            var cover1917 = Path.Combine(imageDirectory, "1917_cover.jpg");
            var rushCover = Path.Combine(imageDirectory, "rush_cover.jpg");
            var viceCover = Path.Combine(imageDirectory, "vice_cover.jpg");
            var johnCover = Path.Combine(imageDirectory, "john_wick_cover.jpg");
            var cherryCover = Path.Combine(imageDirectory, "cherry_cover.jpg");

            IList<Movie> defaultMovies = new List<Movie>
            {
                new Movie
                {
                    Title = "Tenet",
                    Director = "Christopher Nolan",
                    Protagonist = "John David Washington",
                    Duration = 150,
                    Description = "Armed with only one word, Tenet, and fighting for the survival of the entire world, a Protagonist journeys through a twilight world of international espionage on a mission that will unfold in something beyond real time.",
                    Added = DateTime.Now,
                    Image = File.Exists(tenetPath) ? File.ReadAllBytes(tenetPath) : null,
                    Cover = File.Exists(tenetCover) ? File.ReadAllBytes(tenetCover) : null,
                    Screenings = new List<Screening>
                    {
                        new Screening
                        {
                            StartTime = DateTime.Now.AddDays(5),
                            Rooms = new List<Room>
                            {
                                new Room
                                {
                                    Name = "Room 1",
                                    Rows = 3,
                                    Columns = 2,
                                    Seats = new List<Seat>
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
                                        }
                                    }
                                }
                            }
                        },
                        new Screening
                        {
                            StartTime = DateTime.Now.AddDays(6),
                            Rooms = new List<Room>
                            {
                                new Room
                                {
                                    Name = "Room 7",
                                    Rows = 3,
                                    Columns = 2,
                                    Seats = new List<Seat>
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
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                new Movie
                {
                    Title = "1917",
                    Director = "Sam Mendes",
                    Protagonist = "Dean-Charles Chapman",
                    Duration = 119,
                    Description = "April 6th, 1917. As a regiment assembles to wage war deep in enemy territory, two soldiers are assigned to race against time and deliver a message that will stop 1,600 men from walking straight into a deadly trap.",
                    Added = DateTime.Now,
                    Image = File.Exists(path1917) ? File.ReadAllBytes(path1917) : null,
                    Cover = File.Exists(cover1917) ? File.ReadAllBytes(cover1917) : null,
                    Screenings = new List<Screening>
                    {
                        new Screening
                        {
                            StartTime = DateTime.Now.AddDays(7),
                            Rooms = new List<Room>
                            {
                                new Room
                                {
                                    Name = "Room 2",
                                    Rows = 3,
                                    Columns = 2,
                                    Seats = new List<Seat>
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
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                new Movie
                {
                    Title = "Rush",
                    Director = "Ron Howard",
                    Protagonist = "Daniel Brühl",
                    Duration = 123,
                    Description = "The merciless 1970s rivalry between Formula One rivals James Hunt and Niki Lauda.",
                    Added = DateTime.Now,
                    Image = File.Exists(rushPath) ? File.ReadAllBytes(rushPath) : null,
                    Cover = File.Exists(rushCover) ? File.ReadAllBytes(rushCover) : null,
                    Screenings = new List<Screening>
                    {
                        new Screening
                        {
                            StartTime = DateTime.Now.AddDays(15),
                            Rooms = new List<Room>
                            {
                                new Room
                                {
                                    Name = "Room 3",
                                    Rows = 3,
                                    Columns = 2,
                                    Seats = new List<Seat>
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
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                new Movie
                {
                    Title = "Vice",
                    Director = "Adam Mckay",
                    Protagonist = "Christian Bale",
                    Duration = 132,
                    Description = "The story of Dick Cheney, an unassuming bureaucratic Washington insider, who quietly wielded immense power as Vice President to George W. Bush, reshaping the country and the globe in ways that we still feel today.",
                    Added = DateTime.Now,
                    Image = File.Exists(vicePath) ? File.ReadAllBytes(vicePath) : null,
                    Cover = File.Exists(viceCover) ? File.ReadAllBytes(viceCover) : null,
                    Screenings = new List<Screening>
                    {
                        new Screening
                        {
                            StartTime = DateTime.Now.AddDays(10),
                            Rooms = new List<Room>
                            {
                                new Room
                                {
                                    Name = "Room 4",
                                    Rows = 3,
                                    Columns = 2,
                                    Seats = new List<Seat>
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
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                new Movie
                {
                    Title = "John Wick",
                    Director = "Chad Stahelski",
                    Protagonist = "Keanu Reeves",
                    Duration = 101,
                    Description = "An ex-hit-man comes out of retirement to track down the gangsters that killed his dog and took everything from him.",
                    Added = DateTime.Now,
                    Image = File.Exists(johnPath) ? File.ReadAllBytes(johnPath) : null,
                    Cover = File.Exists(johnCover) ? File.ReadAllBytes(johnCover) : null,
                    Screenings = new List<Screening>
                    {
                        new Screening
                        {
                            StartTime = DateTime.Now.AddDays(5),
                            Rooms = new List<Room>
                            {
                                new Room
                                {
                                    Name = "Room 5",
                                    Rows = 3,
                                    Columns = 2,
                                    Seats = new List<Seat>
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
                                            Row = 2,
                                            Column = 1,
                                            Status = 0,
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
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                new Movie
                {
                    Title = "Cherry",
                    Director = "Athony Russo",
                    Protagonist = "Tom Holland",
                    Duration = 142,
                    Description = "An Army medic suffering from post-traumatic stress disorder becomes a serial bank robber after an addiction to drugs puts him in debt.",
                    Added = DateTime.Now,
                    Image = File.Exists(cherryPath) ? File.ReadAllBytes(cherryPath) : null,
                    Cover = File.Exists(cherryCover) ? File.ReadAllBytes(cherryCover) : null,
                    Screenings = new List<Screening>
                    {
                        new Screening
                        {
                            StartTime = DateTime.Now.AddDays(8),
                            Rooms = new List<Room>
                            {
                                new Room
                                {
                                    Name = "Room 6",
                                    Rows = 3,
                                    Columns = 2,
                                    Seats = new List<Seat>
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
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            context.AddRange(defaultMovies);
            context.SaveChanges();
        }
    }
}
