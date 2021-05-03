using Cinema.Desktop.Model;
using Cinema.Persistence.DTO;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace Cinema.Desktop.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields

        private readonly CinemaApiService _service;
        private ObservableCollection<MovieDto> _movies;
        private ObservableCollection<ScreeningDto> _screenings;

        #endregion

        #region Properties

        public ObservableCollection<MovieDto> Movies
        {
            get { return _movies; }
            set { _movies = value; OnPropertyChanged(); }
        }

        public ObservableCollection<ScreeningDto> Screenings
        {
            get { return _screenings; }
            set { _screenings = value; OnPropertyChanged(); }
        }

        #endregion

        #region Commands

        public DelegateCommand RefreshMoviesCommand { get; private set; }
        public DelegateCommand SelectCommand { get; private set; }

        #endregion

        #region Constructor

        public MainViewModel(CinemaApiService service)
        {
            _service = service;
            RefreshMoviesCommand = new DelegateCommand(_ => LoadMovieAsync());
            SelectCommand = new DelegateCommand(param => LoadScreeningsAsync(param as MovieDto));
        }

        #endregion

        #region Methods

        private async void LoadMovieAsync()
        {
            try
            {
                Movies = new ObservableCollection<MovieDto>(await _service.LoadMoviesAsync());
            }
            catch (Exception e) when (e is NetworkException || e is HttpRequestException)
            {
                OnMessageApplication($"Unexpected error occured ({e.Message})");
            }
        }

        private async void LoadScreeningsAsync(MovieDto movieDto)
        {
            if (movieDto == null) return;

            try
            {
                Screenings = new ObservableCollection<ScreeningDto>(await _service.LoadScreeningsAsync(movieDto.Id));
            }
            catch (Exception e) when (e is NetworkException || e is HttpRequestException)
            {
                OnMessageApplication($"Unexpected error occured ({e.Message})");
            }
        }

        #endregion
    }
}
