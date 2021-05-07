using System;

namespace Cinema.Persistence.DTO
{
    public class ScreeningDto
    {
        #region Properties

        public int Id { get; set; }

        public int MovieId { get; set; }

        public DateTime StartTime { get; set; }

        public int RoomId { get; set; }

        #endregion

        #region Methods

        public bool IsValid()
        {
            if (RoomId == 0 || MovieId == 0)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Operators

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

        #endregion
    }
}
