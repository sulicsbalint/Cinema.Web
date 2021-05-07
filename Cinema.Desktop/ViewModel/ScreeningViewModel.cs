using Cinema.Persistence.DTO;
using System;

namespace Cinema.Desktop.ViewModel
{
    public class ScreeningViewModel : ViewModelBase
    {
        #region Fields

        private int _id;
        private DateTime _startTime;
        private int _movieId;
        private int _roomId;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }

        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; OnPropertyChanged(); }
        }

        public int MovieId
        {
            get { return _movieId; }
            set { _movieId = value; OnPropertyChanged(); }
        }

        public int RoomId
        {
            get { return _roomId; }
            set { _roomId = value; OnPropertyChanged(); }
        }

        #endregion

        #region Methods

        public ScreeningViewModel ShallowClone()
        {
            return (ScreeningViewModel)this.MemberwiseClone();
        }

        public void CopyFrom(ScreeningViewModel rhs)
        {
            Id = rhs.Id;
            StartTime = rhs.StartTime;
            MovieId = rhs.MovieId;
            RoomId = rhs.RoomId;
        }

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

        public static explicit operator ScreeningViewModel(ScreeningDto dto) => new ScreeningViewModel
        {
            Id = dto.Id,
            StartTime = dto.StartTime,
            MovieId = dto.MovieId,
            RoomId = dto.RoomId
        };

        public static explicit operator ScreeningDto(ScreeningViewModel vm) => new ScreeningDto
        {
            Id = vm.Id,
            StartTime = vm.StartTime,
            MovieId = vm.MovieId,
            RoomId = vm.RoomId
        };

        #endregion
    }
}
