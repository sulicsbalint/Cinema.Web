using Cinema.Persistence.DTO;
using System;

namespace Cinema.Desktop.ViewModel
{
    public class MovieViewModel : ViewModelBase
    {
        #region Fields

        private int _id;
        private String _title;
        private String _star;
        private String _director;
        private String _description;
        private int _duration;
        private byte[] _image;
        private byte[] _cover;
        private DateTime _added;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }

        public String Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }

        public String Star
        {
            get { return _star; }
            set { _star = value; }
        }

        public String Director
        {
            get { return _director; }
            set { _director = value; }
        }

        public String Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(); }
        }

        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        public byte[] Image
        {
            get { return _image; }
            set { _image = value; OnPropertyChanged(); }
        }

        public byte[] Cover
        {
            get { return _cover; }
            set { _cover = value; }
        }

        public DateTime Added
        {
            get { return _added; }
            set { _added = value; OnPropertyChanged(); }
        }

        #endregion

        #region Methods

        public MovieViewModel ShallowClone()
        {
            return (MovieViewModel)this.MemberwiseClone();
        }

        public void CopyFrom(MovieViewModel rhs)
        {
            Id = rhs.Id;
            Title = rhs.Title;
            Director = rhs.Director;
            Star = rhs.Star;
            Description = rhs.Description;
            Duration = rhs.Duration;
            Image = rhs.Image;
            Cover = rhs.Cover;
            Added = rhs.Added;
        }

        public bool IsValid()
        {
            if (Title is null || Director is null || Star is null || Image is null || Cover is null || Description is null || Duration == 0)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Operators

        public static explicit operator MovieViewModel(MovieDto dto) => new MovieViewModel
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

        public static explicit operator MovieDto(MovieViewModel vm) => new MovieDto
        {
            Id = vm.Id,
            Title = vm.Title,
            Director = vm.Director,
            Star = vm.Star,
            Description = vm.Description,
            Duration = vm.Duration,
            Image = vm.Image,
            Cover = vm.Cover,
            Added = vm.Added
        };

        #endregion
    }
}
