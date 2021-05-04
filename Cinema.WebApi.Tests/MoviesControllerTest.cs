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
    public class MoviesControllerTest : IDisposable
    {
        private readonly CinemaDbContext _context;
        private readonly CinemaService _service;
        private readonly MoviesController _controller;

        public MoviesControllerTest()
        {
            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;

            _context = new CinemaDbContext(options);

            TestDbInitializer.Initialize(_context);

            _service = new CinemaService(_context);
            _controller = new MoviesController(_service);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public void GetMoviesTest()
        {
            // Act
            var result = _controller.GetMovies();

            // Assert
            var content = Assert.IsAssignableFrom<IEnumerable<MovieDto>>(result.Value);
            Assert.Equal(2, content.Count());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void GetListByIdTest(Int32 id)
        {
            // Act
            var result = _controller.GetMovie(id);

            // Assert
            var content = Assert.IsAssignableFrom<MovieDto>(result.Value);
            Assert.Equal(id, content.Id);
        }

        [Fact]
        public void GetInvalidListTest()
        {
            // Arrange
            var id = 3;

            // Act
            var result = _controller.GetMovie(id);

            // Assert
            Assert.IsAssignableFrom<NotFoundResult>(result.Result);
        }

        [Fact]
        public void PostListTest()
        {
            // Arrange
            var newMovie = new MovieDto { Title = "New test movie" };
            var count = _context.Movies.Count();

            // Act
            var result = _controller.PostMovie(newMovie);

            // Assert
            var objectResult = Assert.IsAssignableFrom<CreatedAtActionResult>(result.Result);
            var content = Assert.IsAssignableFrom<MovieDto>(objectResult.Value);
            Assert.Equal(count + 1, _context.Movies.Count());
        }
    }
}
