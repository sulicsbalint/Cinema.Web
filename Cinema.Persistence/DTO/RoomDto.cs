namespace Cinema.Persistence.DTO
{
    public class RoomDto
    {
        #region Properties

        public int Id { get; set; }

        public string Name { get; set; }

        public int Rows { get; set; }

        public int Columns { get; set; }

        #endregion

        #region Operators

        public static explicit operator RoomDto(Room room) => new RoomDto
        {
            Id = room.Id,
            Name = room.Name,
            Rows = room.Rows,
            Columns = room.Columns
        };

        public static explicit operator Room(RoomDto dto) => new Room
        {
            Id = dto.Id,
            Name = dto.Name,
            Rows = dto.Rows,
            Columns = dto.Columns
        };

        #endregion
    }
}
