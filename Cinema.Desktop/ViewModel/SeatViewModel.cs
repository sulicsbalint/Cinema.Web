using Cinema.Persistence.DTO;

namespace Cinema.Desktop.ViewModel
{
    public class SeatViewModel
    {
        #region Fields

        private int _id;
        private int _screeningId;
        private int _row;
        private int _column;
        private int _status;
        private string _reserverName;
        private string _reserverPhone;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int ScreeningId
        {
            get { return _screeningId; }
            set { _screeningId = value; }
        }

        public int Row
        {
            get { return _row; }
            set { _row = value; }
        }

        public int Column
        {
            get { return _column; }
            set { _column = value; }
        }

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string ReserverName
        {
            get { return _reserverName; }
            set { _reserverName = value; }
        }

        public string ReserverPhone
        {
            get { return _reserverPhone; }
            set { _reserverPhone = value; }
        }

        #endregion

        #region Methods

        public SeatViewModel ShallowClone()
        {
            return (SeatViewModel)this.MemberwiseClone();
        }

        public void CopyFrom(SeatViewModel rhs)
        {
            Id = rhs.Id;
            ScreeningId = rhs.ScreeningId;
            Row = rhs.Row;
            Column = rhs.Column;
            Status = rhs.Status;
            ReserverName = rhs.ReserverName;
            ReserverPhone = rhs.ReserverPhone;
        }

        #endregion

        #region Operators

        public static explicit operator SeatViewModel(SeatDto dto) => new SeatViewModel
        {
            Id = dto.Id,
            ScreeningId = dto.ScreeningId,
            Row = dto.Row,
            Column = dto.Column,
            Status = dto.Status,
            ReserverName = dto.ReserverName,
            ReserverPhone = dto.ReserverPhone
        };

        public static explicit operator SeatDto(SeatViewModel vm) => new SeatDto
        {
            Id = vm.Id,
            ScreeningId = vm.ScreeningId,
            Row = vm.Row,
            Column = vm.Column,
            Status = vm.Status,
            ReserverName = vm.ReserverName,
            ReserverPhone = vm.ReserverPhone
        };

        #endregion
    }
}
