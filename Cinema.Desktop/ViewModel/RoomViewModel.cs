using Cinema.Persistence.DTO;

namespace Cinema.Desktop.ViewModel
{
    public class RoomViewModel
    {
        #region Fields

        private int _id;
        private string _name;
        private int _rows;
        private int _columns;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Rows
        {
            get { return _rows; }
            set { _rows = value; }
        }

        public int Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }

        #endregion

        #region Operators

        public static explicit operator RoomViewModel(RoomDto dto) => new RoomViewModel
        {
            Id = dto.Id,
            Name = dto.Name,
            Rows = dto.Rows,
            Columns = dto.Columns
        };

        public static explicit operator RoomDto(RoomViewModel vm) => new RoomDto
        {
            Id = vm.Id,
            Name = vm.Name,
            Rows = vm.Rows,
            Columns = vm.Columns
        };

        #endregion
    }
}
