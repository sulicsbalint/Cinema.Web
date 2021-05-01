using System;

namespace Cinema.Persistence.DTO
{
    public class MovieDto
    {
        public Int32 Id { get; set; }

        public String Title { get; set; }

        public String Director { get; set; }

        public String Star { get; set; }

        public String Description { get; set; }

        public Int32 Duration { get; set; }

        public byte[] Image { get; set; }

        public byte[] Cover { get; set; }

        public DateTime Added { get; set; }

        public static explicit operator Movie(MovieDto dto) => new Movie
        { 
            Id = dto.Id,
            Title = dto.Title,
            Director = dto.Director,
            Star = dto.Star,
            Description = dto.Description,
            Duration = dto.Duration,
            Image = dto.Image,
            Cover = dto.Cover,
            Added = dto.Added
        };

        public static explicit operator MovieDto(Movie m) => new MovieDto
        {
            Id = m.Id,
            Title = m.Title,
            Director = m.Director,
            Star = m.Star,
            Description = m.Description,
            Duration = m.Duration,
            Image = m.Image,
            Cover = m.Cover,
            Added = m.Added
        };
    }
}
