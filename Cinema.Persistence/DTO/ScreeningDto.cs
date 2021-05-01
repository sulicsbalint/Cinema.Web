using System;

namespace Cinema.Persistence.DTO
{
    public class ScreeningDto
    {
        public Int32 Id { get; set; }

        public Int32 MovieId { get; set; }

        public DateTime StartTime { get; set; }

        public Int32 RoomId { get; set; }

        public static explicit operator Screening(ScreeningDto dto) => new Screening
        {
            Id = dto.Id,
            MovieId = dto.MovieId,
            StartTime = dto.StartTime,
            RoomId = dto.RoomId
        };

        public static explicit operator ScreeningDto(Screening s) => new ScreeningDto
        {
            Id = s.Id,
            MovieId = s.MovieId,
            StartTime = s.StartTime,
            RoomId = s.RoomId
        };
    }
}
