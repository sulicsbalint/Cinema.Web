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
        private ObservableCollection<MovieViewModel> _movies;
        private ObservableCollection<ScreeningDto> _screenings;
        private MovieViewModel _selectedMovie;
        private MovieViewModel _editableMovie;
        private MovieViewModel _createableMovie;
        private String _selectedMovieTitle;

        #endregion

        #region Properties

        public ObservableCollection<MovieViewModel> Movies
        {
            get { return _movies; }
            set { _movies = value; OnPropertyChanged(); }
        }

        public ObservableCollection<ScreeningDto> Screenings
        {
            get { return _screenings; }
            set { _screenings = value; OnPropertyChanged(); }
        }

        public MovieViewModel SelectedMovie
        {
            get { return _selectedMovie; }
            set { _selectedMovie = value; OnPropertyChanged(); }
        }
        
        public MovieViewModel EditableMovie
        {
            get { return _editableMovie; }
            set { _editableMovie = value; OnPropertyChanged(); }
        }
        
        public MovieViewModel CreateableMovie
        {
            get { return _createableMovie; }
            set { _createableMovie = value; OnPropertyChanged(); }
        }

        public String SelectedMovieTitle
        {
            get { return _selectedMovieTitle; }
            set { _selectedMovieTitle = value; OnPropertyChanged(); }
        }

        #endregion

        #region Commands

        public DelegateCommand RefreshMoviesCommand { get; private set; }
        public DelegateCommand SelectCommand { get; private set; }
        public DelegateCommand LogoutCommand { get; private set; }
        public DelegateCommand AddMovieCommand { get; private set; }
        public DelegateCommand EditMovieCommand { get; private set; }
        public DelegateCommand DeleteMovieCommand { get; private set; }

        public DelegateCommand SaveMovieEditCommand { get; private set; }
        public DelegateCommand CancelMovieEditCommand { get; private set; }
        public DelegateCommand ChangeImageCommand { get; private set; }

        public DelegateCommand SaveMovieCreateCommand { get; private set; }
        public DelegateCommand CancelMovieCreateCommand { get; private set; }
        public DelegateCommand AddImageCommand { get; private set; }

        #endregion

        #region Events

        public event EventHandler LogoutSucceeded;

        public event EventHandler StartingMovieEdit;
        public event EventHandler FinishingMovieEdit;
        public event EventHandler StartingImageChange;

        public event EventHandler StartingMovieCreate;
        public event EventHandler FinishingMovieCreate;
        public event EventHandler StartingImageAdd;

        #endregion

        #region Constructor

        public MainViewModel(CinemaApiService service)
        {
            _service = service;
            RefreshMoviesCommand = new DelegateCommand(_ => LoadMoviesAsync());
            SelectCommand = new DelegateCommand(_ => LoadScreeningsAsync(SelectedMovie));
            LogoutCommand = new DelegateCommand(_ => LogoutAsync());

            AddMovieCommand = new DelegateCommand(_ => StartCreateMovie());
            EditMovieCommand = new DelegateCommand(_ => !(SelectedMovie is null), _ => StartEditMovie());
            DeleteMovieCommand = new DelegateCommand(_ => !(SelectedMovie is null), _ => DeleteMovie(SelectedMovie));

            SaveMovieEditCommand = new DelegateCommand(_ => SaveMovieEdit());
            CancelMovieEditCommand = new DelegateCommand(_ => CancelMovieEdit());
            ChangeImageCommand = new DelegateCommand(_ => StartingImageChange?.Invoke(this, EventArgs.Empty));

            SaveMovieCreateCommand = new DelegateCommand(_ => SaveMovieCreate());
            CancelMovieCreateCommand = new DelegateCommand(_ => CancelMovieCreate());
            AddImageCommand = new DelegateCommand(_ => StartingImageAdd?.Invoke(this, EventArgs.Empty));
        }

        #endregion

        #region Movie methods

        private async void LoadMoviesAsync()
        {
            try
            {
                Movies = new ObservableCollection<MovieViewModel>(await _service.LoadMoviesAsync());
            }
            catch (Exception e) when (e is NetworkException || e is HttpRequestException)
            {
                OnMessageApplication($"Unexpected error occured ({e.Message})");
            }
        }

        private void StartEditMovie()
        {
            EditableMovie = SelectedMovie.ShallowClone();
            StartingMovieEdit?.Invoke(this, EventArgs.Empty);
        }

        private async void SaveMovieEdit()
        {
            try
            {
                SelectedMovie.CopyFrom(EditableMovie);
                await _service.UpdateMovieAsync((MovieDto)SelectedMovie);
            }
            catch (Exception ex) when (ex is NetworkException || ex is HttpRequestException)
            {
                OnMessageApplication($"Unexpected error occured! ({ex.Message})");
            }
            FinishingMovieEdit?.Invoke(this, EventArgs.Empty);
        }

        private void CancelMovieEdit()
        {
            EditableMovie = null;
            FinishingMovieEdit?.Invoke(this, EventArgs.Empty);
        }

        private void StartCreateMovie()
        {
            var newMovie = new MovieViewModel
            {
                Title = "New Title"
            };

            CreateableMovie = newMovie.ShallowClone();
            StartingMovieCreate?.Invoke(this, EventArgs.Empty);
        }

        private async void SaveMovieCreate()
        {
            try
            {
                var newMovie = new MovieViewModel();
                newMovie.CopyFrom(CreateableMovie);
                var movieDto = (MovieDto)newMovie;
                await _service.CreateMovieAsync(movieDto);
                newMovie.Id = movieDto.Id;
                Movies.Add(newMovie);
                SelectedMovie = newMovie;
            }
            catch (Exception ex) when (ex is NetworkException || ex is HttpRequestException)
            {
                OnMessageApplication($"Unexpected error occured! ({ex.Message})");
            }
            FinishingMovieCreate?.Invoke(this, EventArgs.Empty);
        }

        private void CancelMovieCreate()
        {
            CreateableMovie = null;
            FinishingMovieCreate?.Invoke(this, EventArgs.Empty);
        }

        private async void DeleteMovie(MovieViewModel movie)
        {
            try
            {
                await _service.DeleteMovieAsync(movie.Id);
                Movies.Remove(SelectedMovie);
                SelectedMovie = null;
            }
            catch (Exception ex) when (ex is NetworkException || ex is HttpRequestException)
            {
                OnMessageApplication($"Unexpected error occured! ({ex.Message})");
            }
        }

        #endregion

        #region Methods

        private async void LoadScreeningsAsync(MovieViewModel movie)
        {
            if (movie == null) return;

            try
            {
                SelectedMovieTitle = movie.Title;
                Screenings = new ObservableCollection<ScreeningDto>(await _service.LoadScreeningsAsync(movie.Id));
            }
            catch (Exception e) when (e is NetworkException || e is HttpRequestException)
            {
                OnMessageApplication($"Unexpected error occured ({e.Message})");
            }
        }

        private async void LogoutAsync()
        {
            try
            {
                await _service.LogoutAsync();
                
                LogoutSucceeded?.Invoke(this, EventArgs.Empty);

            }
            catch (Exception ex) when (ex is NetworkException || ex is HttpRequestException)
            {
                OnMessageApplication($"Unexpected error occured! ({ex.Message})");
            }
        }

        #endregion
    }
}
