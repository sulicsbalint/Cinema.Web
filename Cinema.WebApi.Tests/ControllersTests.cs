using Cinema.Persistence;
using Cinema.Persistence.DTO;
using Cinema.Persistence.Services;
using Cinema.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cinema.WebApi.Tests
{
    public class ControllersTests : IDisposable
    {
        private readonly CinemaDbContext _context;
        private readonly CinemaService _service;
        private readonly MoviesController _movieController;
        private readonly ScreeningsController _screeningController;
        private readonly RoomsController _roomController;
        private readonly SeatsController _seatController;

        public ControllersTests()
        {
            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;

            _context = new CinemaDbContext(options);

            TestDbInitializer.Initialize(_context);

            _service = new CinemaService(_context);
            _movieController = new MoviesController(_service);
            _screeningController = new ScreeningsController(_service);
            _roomController = new RoomsController(_service);
            _seatController = new SeatsController(_service);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        // Movies
        [Fact]
        public void GetMoviesTest()
        {
            // Act
            var result = _movieController.GetMovies();

            // Assert
            var content = Assert.IsAssignableFrom<IEnumerable<MovieDto>>(result.Value);
            Assert.Equal(2, content.Count());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void GetMovieByIdTest(Int32 id)
        {
            // Act
            var result = _movieController.GetMovie(id);

            // Assert
            var content = Assert.IsAssignableFrom<MovieDto>(result.Value);
            Assert.Equal(id, content.Id);
        }

        [Fact]
        public void GetInvalidMovieTest()
        {
            // Arrange
            var id = 3;

            // Act
            var result = _movieController.GetMovie(id);

            // Assert
            Assert.IsAssignableFrom<NotFoundResult>(result.Result);
        }

        [Fact]
        public void PostMovieTest()
        {
            // Arrange
            var newMovie = new MovieDto { Title = "New test movie" };
            var count = _context.Movies.Count();

            // Act
            var result = _movieController.PostMovie(newMovie);

            // Assert
            var objectResult = Assert.IsAssignableFrom<CreatedAtActionResult>(result.Result);
            var content = Assert.IsAssignableFrom<MovieDto>(objectResult.Value);
            Assert.Equal(count + 1, _context.Movies.Count());
        }

        // Screening
        [Fact]
        public void GetScreeningsTest()
        {
            // Act
            var result = _screeningController.GetScreenings(2);

            // Assert
            var content = Assert.IsAssignableFrom<IEnumerable<ScreeningDto>>(result.Value);
            Assert.Equal(2, content.Count());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetScreeningByIdTest(Int32 id)
        {
            // Act
            var result = _screeningController.GetScreening(id);

            // Assert
            var content = Assert.IsAssignableFrom<ScreeningDto>(result.Value);
            Assert.Equal(id, content.Id);
        }

        [Fact]
        public void GetInvalidScreeningTest()
        {
            // Arrange
            var id = 4;

            // Act
            var result = _screeningController.GetScreening(id);

            // Assert
            Assert.IsAssignableFrom<NotFoundResult>(result.Result);
        }

        [Fact]
        public void PostScreeningTest()
        {
            // Arrange
            var newScreening = new ScreeningDto { StartTime = DateTime.Now, MovieId = 1, RoomId = 1 };
            var count = _context.Screenings.Count();

            // Act
            var result = _screeningController.PostScreening(newScreening);

            // Assert
            var objectResult = Assert.IsAssignableFrom<CreatedAtActionResult>(result.Result);
            var content = Assert.IsAssignableFrom<ScreeningDto>(objectResult.Value);
            Assert.Equal(count + 1, _context.Screenings.Count());
        }

        // Room
        [Fact]
        public void GetRoomsTest()
        {
            // Act
            var result = _roomController.GetRooms();

            // Assert
            var content = Assert.IsAssignableFrom<IEnumerable<RoomDto>>(result.Value);
            Assert.Equal(2, content.Count());
        }

        // Seat
        [Fact]
        public void GetSeatsTest()
        {
            // Act
            var result = _seatController.GetSeats(2);

            // Assert
            var content = Assert.IsAssignableFrom<IEnumerable<SeatDto>>(result.Value);
            Assert.Equal(3, content.Count());
        }
    }
}
