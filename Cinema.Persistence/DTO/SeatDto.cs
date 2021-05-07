namespace Cinema.Persistence.DTO
{
    public class SeatDto
    {
        #region Properties

        public int Id { get; set; }

        public int ScreeningId { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public int Status { get; set; }

        public string ReserverName { get; set; }

        public string ReserverPhone { get; set; }

        #endregion

        #region Methods

        public bool IsValid()
        {
            if (ReserverName is null || ReserverPhone is null)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Operators

        public static explicit operator Seat(SeatDto dto) => new Seat
        {
            Id = dto.Id,
            ScreeningId = dto.ScreeningId,
            Row = dto.Row,
            Column = dto.Column,
            Status = dto.Status,
            ReserverName = dto.ReserverName,
            ReserverPhone = dto.ReserverPhone
        };

        public static explicit operator SeatDto(Seat s) => new SeatDto
        {
            Id = s.Id,
            ScreeningId = s.ScreeningId,
            Row = s.Row,
            Column = s.Column,
            Status = s.Status,
            ReserverName = s.ReserverName,
            ReserverPhone = s.ReserverPhone
        };

        #endregion
    }
}
