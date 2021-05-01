using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cinema.Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(CinemaDbContext context, string imageDirectory)
        {
            //context.Database.Migrate();

            if (context.Movies.Any()) return;

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

            List<Screening> tenetScreenings = new List<Screening>
            {
                new Screening
                {
                    StartTime = DateTime.Now.AddDays(1),
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
                    }
                },
                new Screening
                {
                    StartTime = DateTime.Now.AddDays(4),
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
                    }
                }
            };

            List<Screening> screenings1917 = new List<Screening>
            {
                new Screening
                {
                    StartTime = DateTime.Now.AddDays(1),
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
                    }
                },
                new Screening
                {
                    StartTime = DateTime.Now.AddDays(2),
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
                    }
                }
            };

            List<Screening> rushScreenings = new List<Screening>
            {
                new Screening
                {
                    StartTime = DateTime.Now.AddDays(3),
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
                    }
                }
            };

            List<Screening> viceScreenings = new List<Screening>
            {
                new Screening
                {
                    StartTime = DateTime.Now.AddDays(2),
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
                    }
                }
            };

            List<Screening> johnWickScreenings = new List<Screening>
            {
                new Screening
                {
                    StartTime = DateTime.Now.AddDays(3),
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
                    }
                }
            };

            List<Screening> cherryScreenings = new List<Screening>
            {
                new Screening
                {
                    StartTime = DateTime.Now.AddDays(3),
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
                    }
                }
            };

            IList<Movie> defaultMovies = new List<Movie>
            {
                new Movie
                {
                    Title = "Cherry",
                    Director = "Athony Russo",
                    Star = "Tom Holland",
                    Duration = 142,
                    Description = "Cherry (Tom Holland) kimarad a főiskoláról, majd az élet a hadseregbe sodorja, ahol szanitéc lesz Irakban – ezalatt egyetlen támasza igaz szerelme, Emily (Ciara Bravo). A háborúból visszatérve a poszttraumás stressz nyomása alatt élete a drogok és a bűnözés spiráljába kerül, miközben azért küzd, hogy megtalálja helyét a világban.",
                    Added = DateTime.Now,
                    Image = File.Exists(cherryPath) ? File.ReadAllBytes(cherryPath) : null,
                    Cover = File.Exists(cherryCover) ? File.ReadAllBytes(cherryCover) : null,
                    Screenings = cherryScreenings
                },
                new Movie
                {
                    Title = "Tenet",
                    Director = "Christopher Nolan",
                    Star = "John David Washington",
                    Duration = 150,
                    Description = "A legsikeresebb Batman-trilógia és az Eredet rendezője, Christopher Nolan ismét különlegesen egyedi, izgalmas és meghökkentő fordulatokban gazdag thrillert rendezett, amelyen egy angol kémnek kellene megmentenie a Földet a rá leselkedő és pusztulással fenyegető katasztrófától. Ám a szuperügynöknek nemcsak az idegen hatalmak embereivel, hanem a legnagyobb ellenséggel, az Idővel is meg kell küzdenie.",
                    Added = DateTime.Now,
                    Image = File.Exists(tenetPath) ? File.ReadAllBytes(tenetPath) : null,
                    Cover = File.Exists(tenetCover) ? File.ReadAllBytes(tenetCover) : null,
                    Screenings = tenetScreenings
                },
                new Movie
                {
                    Title = "1917",
                    Director = "Sam Mendes",
                    Star = "Dean-Charles Chapman",
                    Duration = 119,
                    Description = "Javában zajlik az I. világháború, amikor két fiatal brit katonát egy lehetetlennek tűnő küldetéssel bíznak meg: az ellenséges vonalon kell áthatolniuk, hogy egy üzenetet kézbesítsenek bajtársaiknak. Egy napjuk van, hogy célhoz érjenek, különben 1600 társuk, köztük egyikük testvére is odavész. A két bátor harcos hihetetlen elszántsággal indul neki a német frontnak…",
                    Added = DateTime.Now,
                    Image = File.Exists(path1917) ? File.ReadAllBytes(path1917) : null,
                    Cover = File.Exists(cover1917) ? File.ReadAllBytes(cover1917) : null,
                    Screenings = screenings1917
                },
                new Movie
                {
                    Title = "Rush",
                    Director = "Ron Howard",
                    Star = "Daniel Brühl",
                    Duration = 123,
                    Description = "1976 - a Forma 1 aranykora, a hihetetlenül izgalmas, és látványos száguldó cirkusz legendás szezonja, két felejthetetlen versenyző harcával: James Hunt, a vagány brit pilóta, a Forma 1 rocksztárja, és Niki Lauda, az osztrák fegyelmezett zseni, az 1975-ös világbajnok néz egymással farkasszemet a világ legveszélyesebb pályáin. Igazi ellenfelek, akik bármire képesek a győzelemért.",
                    Added = DateTime.Now,
                    Image = File.Exists(rushPath) ? File.ReadAllBytes(rushPath) : null,
                    Cover = File.Exists(rushCover) ? File.ReadAllBytes(rushCover) : null,
                    Screenings = rushScreenings
                },
                new Movie
                {
                    Title = "Vice",
                    Director = "Adam Mckay",
                    Star = "Christian Bale",
                    Duration = 132,
                    Description = "Cheney fél évszázadot felölelő útja során wyomingi elektronikai munkásból az Egyesült Államok de facto elnöke lesz ebben a sötét humorú és gyakran nyugtalanító bepillantásban a szervezeti hatalommal való (vissza)élésbe. McKay értő kezei közt a Cheney-t övező kettősség, mint elhivatott családapa és politikai bábjátékos, bensőségességgel, szellemességgel és merész narratívával találkozik.",
                    Added = DateTime.Now,
                    Image = File.Exists(vicePath) ? File.ReadAllBytes(vicePath) : null,
                    Cover = File.Exists(viceCover) ? File.ReadAllBytes(viceCover) : null,
                    Screenings = viceScreenings
                },
                new Movie
                {
                    Title = "John Wick",
                    Director = "Chad Stahelski",
                    Star = "Keanu Reeves",
                    Duration = 101,
                    Description = "John Wick (Keanu Reeves) nyugodt életre vágyik. Magányosan akarja tölteni a napjait: kutyája, sportkocsija, üres, hideg lakása éppen elég neki - nincs szüksége többre. De egy nyugdíjas bérgyilkos nem pihenhet. És amikor bántják, ő sem marad tétlen. Előveszi rég elrejtett fegyvereit, és elindul véres bosszúhadjáratára. Egyetlen ember harcol gengszterek és bérgyilkosok egész hadserege ellen, New York pedig valódi csatatérré válik.",
                    Added = DateTime.Now,
                    Image = File.Exists(johnPath) ? File.ReadAllBytes(johnPath) : null,
                    Cover = File.Exists(johnCover) ? File.ReadAllBytes(johnCover) : null,
                    Screenings = johnWickScreenings
                }
            };

            IList<Room> defaultRooms = new List<Room>
            {
                new Room
                {
                    Name = "Terem 1",
                    Rows = 3,
                    Columns = 6,
                    Screenings = tenetScreenings
                },
                new Room
                {
                    Name = "Terem 2",
                    Rows = 3,
                    Columns = 6,
                    Screenings = screenings1917
                },
                new Room
                {
                    Name = "Terem 3",
                    Rows = 3,
                    Columns = 6,
                    Screenings = rushScreenings
                },
                new Room
                {
                    Name = "Terem 4",
                    Rows = 3,
                    Columns = 6,
                    Screenings = viceScreenings
                },
                new Room
                {
                    Name = "Terem 5",
                    Rows = 3, 
                    Columns = 6,
                    Screenings = johnWickScreenings
                },
                new Room
                {
                    Name = "Terem 6",
                    Rows = 3, 
                    Columns = 6,
                    Screenings = cherryScreenings
                }
            };

            context.AddRange(defaultMovies);
            context.AddRange(defaultRooms);
            context.SaveChanges();

        }
    }
}
