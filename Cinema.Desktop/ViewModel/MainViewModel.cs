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

        /******************************Movie******************************/
        private ObservableCollection<MovieViewModel> _movies;
        private MovieViewModel _selectedMovie;
        private MovieViewModel _editableMovie;
        private MovieViewModel _createableMovie;

        /****************************Screening****************************/
        private ObservableCollection<ScreeningViewModel> _screenings;
        private ScreeningViewModel _selectedScreening;
        private ScreeningViewModel _editableScreening;
        private ScreeningViewModel _createableScreening;

        /*******************************Room******************************/
        private ObservableCollection<RoomViewModel> _rooms;

        /*******************************Seat******************************/
        private ObservableCollection<SeatViewModel> _seats;
        private SeatViewModel _selectedSeat;
        private SeatViewModel _editableSeat;

        #endregion

        #region Properties

        /******************************Movie******************************/
        public ObservableCollection<MovieViewModel> Movies
        {
            get { return _movies; }
            set { _movies = value; OnPropertyChanged(); }
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

        /******************************Screening******************************/
        public ObservableCollection<ScreeningViewModel> Screenings
        {
            get { return _screenings; }
            set { _screenings = value; OnPropertyChanged(); }
        }

        public ScreeningViewModel SelectedScreening
        {
            get { return _selectedScreening; }
            set { _selectedScreening = value; OnPropertyChanged(); }
        }

        public ScreeningViewModel EditableScreening
        {
            get { return _editableScreening; }
            set { _editableScreening = value; OnPropertyChanged(); }
        }

        public ScreeningViewModel CreateableScreening
        {
            get { return _createableScreening; }
            set { _createableScreening = value; OnPropertyChanged(); }
        }

        /*******************************Room******************************/
        public ObservableCollection<RoomViewModel> Rooms
        {
            get { return _rooms; }
            set { _rooms = value; OnPropertyChanged(); }
        }

        /*******************************Seat******************************/
        public ObservableCollection<SeatViewModel> Seats
        {
            get { return _seats; }
            set { _seats = value; OnPropertyChanged(); }
        }

        public SeatViewModel SelectedSeat
        {
            get { return _selectedSeat; }
            set { _selectedSeat = value; OnPropertyChanged(); }
        }

        public SeatViewModel EditableSeat
        {
            get { return _editableSeat; }
            set { _editableSeat = value; OnPropertyChanged(); }
        }

        #endregion

        #region Commands

        public DelegateCommand RefreshMoviesCommand { get; private set; }
        public DelegateCommand RefreshSeatsCommand { get; private set; }
        public DelegateCommand SelectCommand { get; private set; }
        public DelegateCommand SelectScreeningCommand { get; private set; }
        public DelegateCommand SelectSeatCommand { get; private set; }
        public DelegateCommand LogoutCommand { get; private set; }

        /*****************************Movie*****************************/
        public DelegateCommand AddMovieCommand { get; private set; }
        public DelegateCommand EditMovieCommand { get; private set; }
        public DelegateCommand DeleteMovieCommand { get; private set; }

        //Edit
        public DelegateCommand SaveMovieEditCommand { get; private set; }
        public DelegateCommand CancelMovieEditCommand { get; private set; }
        public DelegateCommand ChangeImageCommand { get; private set; }
        public DelegateCommand ChangeCoverCommand { get; private set; }

        //Add
        public DelegateCommand SaveMovieCreateCommand { get; private set; }
        public DelegateCommand CancelMovieCreateCommand { get; private set; }
        public DelegateCommand AddImageCommand { get; private set; }
        public DelegateCommand AddCoverCommand { get; private set; }

        /*******************************Screening*******************************/
        public DelegateCommand AddScreeningCommand { get; private set; }
        public DelegateCommand EditScreeningCommand { get; private set; }
        public DelegateCommand DeleteScreeningCommand { get; private set; }

        //Add
        public DelegateCommand SaveScreeningCreateCommand { get; private set; }
        public DelegateCommand CancelScreeningCreateCommand { get; private set; }

        //Edit
        public DelegateCommand SaveScreeningEditCommand { get; private set; }
        public DelegateCommand CancelScreeningEditCommand { get; private set; }

        /**********************************Seat**********************************/
        public DelegateCommand EditSeatCommand { get; private set; }

        //Edit
        public DelegateCommand SaveSeatEditCommand { get; private set; }
        public DelegateCommand CancelSeatEditCommand { get; private set; }
        public DelegateCommand SellSeatCommand { get; private set; }

        #endregion

        #region Events

        public event EventHandler LogoutSucceeded;

        /************************Movie************************/
        //Edit
        public event EventHandler StartingMovieEdit;
        public event EventHandler FinishingMovieEdit;
        public event EventHandler StartingImageChange;
        public event EventHandler StartingCoverChange;

        //Add
        public event EventHandler StartingMovieCreate;
        public event EventHandler FinishingMovieCreate;
        public event EventHandler StartingImageAdd;
        public event EventHandler StartingCoverAdd;

        /************************Screening************************/
        //Edit
        public event EventHandler StartingScreeningEdit;
        public event EventHandler FinishingScreeningEdit;

        //Add
        public event EventHandler StartingScreeningCreate;
        public event EventHandler FinishingScreeningCreate;

        /**************************Seat***************************/
        //Edit
        public event EventHandler StartingSeatEdit;
        public event EventHandler FinishingSeatEdit;

        #endregion

        #region Constructor

        public MainViewModel(CinemaApiService service)
        {
            _service = service;
            RefreshMoviesCommand = new DelegateCommand(_ => LoadMoviesAsync());
            SelectCommand = new DelegateCommand(_ => LoadScreeningsAsync(SelectedMovie));
            SelectScreeningCommand = new DelegateCommand(_ => LoadSeatsAsync(SelectedScreening));
            RefreshSeatsCommand = new DelegateCommand(_ => LoadSeatsAsync(SelectedScreening));
            LogoutCommand = new DelegateCommand(_ => LogoutAsync());

            /***********************************************Movie*****************************************************/
            AddMovieCommand = new DelegateCommand(_ => StartCreateMovie());
            EditMovieCommand = new DelegateCommand(_ => !(SelectedMovie is null), _ => StartEditMovie());
            DeleteMovieCommand = new DelegateCommand(_ => !(SelectedMovie is null), _ => DeleteMovie(SelectedMovie));

            //Edit
            SaveMovieEditCommand = new DelegateCommand(_ => SaveMovieEdit());
            CancelMovieEditCommand = new DelegateCommand(_ => CancelMovieEdit());
            ChangeImageCommand = new DelegateCommand(_ => StartingImageChange?.Invoke(this, EventArgs.Empty));
            ChangeCoverCommand = new DelegateCommand(_ => StartingCoverChange?.Invoke(this, EventArgs.Empty));

            //Add
            SaveMovieCreateCommand = new DelegateCommand(_ => SaveMovieCreate());
            CancelMovieCreateCommand = new DelegateCommand(_ => CancelMovieCreate());
            AddImageCommand = new DelegateCommand(_ => StartingImageAdd?.Invoke(this, EventArgs.Empty));
            AddCoverCommand = new DelegateCommand(_ => StartingCoverAdd?.Invoke(this, EventArgs.Empty));

            /******************************************************Screening*************************************************************/
            AddScreeningCommand = new DelegateCommand(_ => !(SelectedMovie is null), _ => StartCreateScreening());
            EditScreeningCommand = new DelegateCommand(_ => !(SelectedScreening is null), _ => StartEditScreening());
            DeleteScreeningCommand = new DelegateCommand(_ => !(SelectedScreening is null), _ => DeleteScreening(SelectedScreening));

            //Edit
            SaveScreeningEditCommand = new DelegateCommand(_ => SaveScreeningEdit());
            CancelScreeningEditCommand = new DelegateCommand(_ => CancelScreeningEdit());

            //Add
            SaveScreeningCreateCommand = new DelegateCommand(_ => SaveScreeningCreate());
            CancelScreeningCreateCommand = new DelegateCommand(_ => CancelScreeningCreate());

            /********************************************************Seat***************************************************************/
            EditSeatCommand = new DelegateCommand(_ => !(SelectedSeat is null), _ => StartEditSeat());

            //Edit
            SaveSeatEditCommand = new DelegateCommand(_ => SaveSeatEdit());
            CancelSeatEditCommand = new DelegateCommand(_ => CancelSeatEdit());
            SellSeatCommand = new DelegateCommand(_ => !(SelectedSeat is null) && (SelectedSeat.Status == 0 || SelectedSeat.Status == 1), _ => SellSeat());
        }

        #endregion

        #region Movie methods

        private async void LoadMoviesAsync()
        {
            try
            {
                Movies = new ObservableCollection<MovieViewModel>(await _service.LoadMoviesAsync());
                Rooms = new ObservableCollection<RoomViewModel>(await _service.LoadRoomsAsync());
            }
            catch (Exception e) when (e is NetworkException || e is HttpRequestException)
            {
                OnMessageApplication($"Unexpected error occured ({e.Message})");
            }
        }

        //Edit
        private void StartEditMovie()
        {
            EditableMovie = SelectedMovie.ShallowClone();
            StartingMovieEdit?.Invoke(this, EventArgs.Empty);
        }

        private async void SaveMovieEdit()
        {
            try
            {
                if (!EditableMovie.IsValid())
                {
                    OnMessageApplication("Minden mezőt ki kell tölteni.");
                    return;
                }
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

        //Add
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
                if (!CreateableMovie.IsValid())
                {
                    OnMessageApplication("Minden mezőt ki kell tölteni.");
                    return;
                }
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

        //Delete
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

        #region Screening methods

        private async void LoadScreeningsAsync(MovieViewModel movie)
        {
            if (movie == null) return;

            try
            {
                Screenings = new ObservableCollection<ScreeningViewModel>(await _service.LoadScreeningsAsync(movie.Id));
            }
            catch (Exception e) when (e is NetworkException || e is HttpRequestException)
            {
                OnMessageApplication($"Unexpected error occured ({e.Message})");
            }
        }

        //Edit
        private void StartEditScreening()
        {
            EditableScreening = SelectedScreening.ShallowClone();
            StartingScreeningEdit?.Invoke(this, EventArgs.Empty);
        }

        private async void SaveScreeningEdit()
        {
            try
            {
                if (!EditableScreening.IsValid())
                {
                    OnMessageApplication("Minden mezőt ki kell tölteni.");
                    return;
                }
                SelectedScreening.CopyFrom(EditableScreening);
                await _service.UpdateScreeningAsync((ScreeningDto)SelectedScreening);
            }
            catch (Exception ex) when (ex is NetworkException || ex is HttpRequestException)
            {
                OnMessageApplication($"Unexpected error occured! ({ex.Message})");
            }
            FinishingScreeningEdit?.Invoke(this, EventArgs.Empty);
        }

        private void CancelScreeningEdit()
        {
            EditableScreening = null;
            FinishingScreeningEdit?.Invoke(this, EventArgs.Empty);
        }

        //Add
        private void StartCreateScreening()
        {
            var newScreening = new ScreeningViewModel
            {
                StartTime = DateTime.Now,
                MovieId = SelectedMovie.Id
            };

            CreateableScreening = newScreening.ShallowClone();
            StartingScreeningCreate?.Invoke(this, EventArgs.Empty);
        }

        private async void SaveScreeningCreate()
        {
            try
            {
                if (!CreateableScreening.IsValid())
                {
                    OnMessageApplication("Minden mezőt ki kell tölteni.");
                    return;
                }
                var newScreening = new ScreeningViewModel();
                newScreening.CopyFrom(CreateableScreening);
                var screeningDto = (ScreeningDto)newScreening;
                await _service.CreateScreeningAsync(screeningDto);
                newScreening.Id = screeningDto.Id;
                Screenings.Add(newScreening);
                SelectedScreening = newScreening;
            }
            catch (Exception ex) when (ex is NetworkException || ex is HttpRequestException)
            {
                OnMessageApplication($"Unexpected error occured! ({ex.Message})");
            }
            catch (Exception)
            {
                OnMessageApplication("A megadott időpontban nem lehet új előadást a megadott teremben létrhozni!");
                return;
            }
            FinishingScreeningCreate?.Invoke(this, EventArgs.Empty);
        }

        private void CancelScreeningCreate()
        {
            CreateableScreening = null;
            FinishingScreeningCreate?.Invoke(this, EventArgs.Empty);
        }

        //Delete
        private async void DeleteScreening(ScreeningViewModel screening)
        {
            try
            {
                await _service.DeleteScreeningAsync(screening.Id);
                Screenings.Remove(SelectedScreening);
                SelectedScreening = null;
            }
            catch (Exception ex) when (ex is NetworkException || ex is HttpRequestException)
            {
                OnMessageApplication($"Unexpected error occured! ({ex.Message})");
            }
        }

        #endregion

        #region Seat methods

        private async void LoadSeatsAsync(ScreeningViewModel screening)
        {
            if (screening == null) return;

            try
            {
                Seats = new ObservableCollection<SeatViewModel>(await _service.LoadSeatsAsync(screening.Id));
            }
            catch (Exception e) when (e is NetworkException || e is HttpRequestException)
            {
                OnMessageApplication($"Unexpected error occured ({e.Message})");
            }
        }

        private void StartEditSeat()
        {
            EditableSeat = SelectedSeat.ShallowClone();
            StartingSeatEdit?.Invoke(this, EventArgs.Empty);
        }

        private async void SaveSeatEdit()
        {
            try
            {
                SelectedSeat.CopyFrom(EditableSeat);
                await _service.UpdateSeatAsync((SeatDto)SelectedSeat);
            }
            catch (Exception ex) when (ex is NetworkException || ex is HttpRequestException)
            {
                OnMessageApplication($"Unexpected error occured! ({ex.Message})");
            }
            FinishingSeatEdit?.Invoke(this, EventArgs.Empty);
        }

        private void CancelSeatEdit()
        {
            EditableSeat = null;
            FinishingSeatEdit?.Invoke(this, EventArgs.Empty);
        }

        private async void SellSeat()
        {
            try
            {
                if (!EditableSeat.IsValid())
                {
                    OnMessageApplication("Minden mezőt ki kell tölteni.");
                    return;
                }
                SelectedSeat.CopyFrom(EditableSeat);
                SelectedSeat.Status = 2;
                await _service.UpdateSeatAsync((SeatDto)SelectedSeat);
            }
            catch (Exception ex) when (ex is NetworkException || ex is HttpRequestException)
            {
                OnMessageApplication($"Unexpected error occured! ({ex.Message})");
            }
            FinishingSeatEdit?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Methods

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
