using Cinema.Desktop.Model;
using Cinema.Desktop.View;
using Cinema.Desktop.ViewModel;
using Microsoft.Win32;
using System;
using System.Configuration;
using System.IO;
using System.Windows;

namespace Cinema.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Fields

        private CinemaApiService _service;
        private MainViewModel _mainViewModel;
        private LoginViewModel _loginViewModel;
        private MainWindow _mainView;
        private LoginWindow _loginView;
        
        private MovieEditorWindow _movieEditorView;
        private MovieCreatorWindow _movieCreatorView;

        private ScreeningCreatorWindow _screeningCreatorView;
        private ScreeningEditorWindow _screeningEditorView;

        private SeatEditorWindow _seatEditorView;

        #endregion

        #region Constructor

        public App()
        {
            Startup += App_Startup;
        }

        #endregion

        #region Methods

        private void App_Startup(object sender, StartupEventArgs e)
        {
            _service = new CinemaApiService(ConfigurationManager.AppSettings["baseAddress"]);

            _loginViewModel = new LoginViewModel(_service);
            _loginViewModel.LoginSucceeded += _loginViewModel_LoginSucceeded;
            _loginViewModel.LoginFailed += _loginViewModel_LoginFailed;
            _loginViewModel.MessageApplication += onMessageApplication;

            _loginView = new LoginWindow
            {
                DataContext = _loginViewModel
            };

            _mainViewModel = new MainViewModel(_service);
            _mainViewModel.MessageApplication += onMessageApplication;
            _mainViewModel.LogoutSucceeded += _mainViewModel_LogoutSucceeded;

            /*************************************Movie*************************************/
            //Edit
            _mainViewModel.StartingMovieEdit += _mainViewModel_StartingMovieEdit;
            _mainViewModel.FinishingMovieEdit += _mainViewModel_FinishingMovieEdit;
            _mainViewModel.StartingImageChange += _mainViewModel_StartingImageChange;
            _mainViewModel.StartingCoverChange += _mainViewModel_StartingCoverChange;

            //Add
            _mainViewModel.StartingMovieCreate += _mainViewModel_StartingMovieCreate;
            _mainViewModel.FinishingMovieCreate += _mainViewModel_FinishingMovieCreate;
            _mainViewModel.StartingImageAdd += _mainViewModel_StartingImageAdd;
            _mainViewModel.StartingCoverAdd += _mainViewModel_StartingCoverAdd;

            /*************************************Screening*************************************/
            //Edit
            _mainViewModel.StartingScreeningEdit += _mainViewModel_StartingScreeningEdit;
            _mainViewModel.FinishingScreeningEdit += _mainViewModel_FinishingScreeningEdit;

            //Add
            _mainViewModel.StartingScreeningCreate += _mainViewModel_StartingScreeningCreate;
            _mainViewModel.FinishingScreeningCreate += _mainViewModel_FinishingScreeningCreate;

            /*************************************Seat*************************************/
            //Edit
            _mainViewModel.StartingSeatEdit += _mainViewModel_StartingSeatEdit;
            _mainViewModel.FinishingSeatEdit += _mainViewModel_FinishingSeatEdit;

            _mainView = new MainWindow
            {
                DataContext = _mainViewModel
            };

            //_mainView.Show();
            _loginView.Show();
        }

        private void _mainViewModel_LogoutSucceeded(object sender, EventArgs e)
        {
            _mainView.Hide();
            _loginView.Show();
        }

        private void _loginViewModel_LoginSucceeded(object sender, EventArgs e)
        {
            _loginView.Hide();
            _mainView.Show();
        }

        private void _loginViewModel_LoginFailed(object sender, EventArgs e)
        {
            MessageBox.Show("Login failed", "Cinema", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        private void onMessageApplication(object sender, MessageEventArgs e)
        {
            MessageBox.Show(e.Message, "Cinema", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        #endregion

        #region Movie methods

        //Edit
        private void _mainViewModel_StartingMovieEdit(object sender, EventArgs e)
        {
            _movieEditorView = new MovieEditorWindow
            {
                DataContext = _mainViewModel
            };
            _movieEditorView.ShowDialog();
        }

        private void _mainViewModel_FinishingMovieEdit(object sender, EventArgs e)
        {
            if (_movieEditorView.IsActive)
            {
                _movieEditorView.Close();
            }
        }

        private async void _mainViewModel_StartingImageChange(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = "Images|*.jpg;*.jpeg;*.bmp;*.tif;*.gif;*.png;",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };

            if (dialog.ShowDialog(_movieEditorView).GetValueOrDefault(false))
            {
                _mainViewModel.EditableMovie.Image = await File.ReadAllBytesAsync(dialog.FileName);
            }
        }

        private async void _mainViewModel_StartingCoverChange(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = "Images|*.jpg;*.jpeg;*.bmp;*.tif;*.gif;*.png;",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };

            if (dialog.ShowDialog(_movieEditorView).GetValueOrDefault(false))
            {
                _mainViewModel.EditableMovie.Cover = await File.ReadAllBytesAsync(dialog.FileName);
            }
        }

        //Add
        private void _mainViewModel_StartingMovieCreate(object sender, EventArgs e)
        {
            _movieCreatorView = new MovieCreatorWindow
            {
                DataContext = _mainViewModel
            };
            _movieCreatorView.ShowDialog();
        }

        private void _mainViewModel_FinishingMovieCreate(object sender, EventArgs e)
        {
            if (_movieCreatorView.IsActive)
            {
                _movieCreatorView.Close();
            }
        }

        private async void _mainViewModel_StartingImageAdd(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = "Images|*.jpg;*.jpeg;*.bmp;*.tif;*.gif;*.png;",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };

            if (dialog.ShowDialog(_movieCreatorView).GetValueOrDefault(false))
            {
                _mainViewModel.CreateableMovie.Image = await File.ReadAllBytesAsync(dialog.FileName);
            }
        }

        private async void _mainViewModel_StartingCoverAdd(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = "Images|*.jpg;*.jpeg;*.bmp;*.tif;*.gif;*.png;",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };

            if (dialog.ShowDialog(_movieCreatorView).GetValueOrDefault(false))
            {
                _mainViewModel.CreateableMovie.Cover = await File.ReadAllBytesAsync(dialog.FileName);
            }
        }

        #endregion

        #region Screening methods

        //Edit
        private void _mainViewModel_StartingScreeningEdit(object sender, EventArgs e)
        {
            _screeningEditorView = new ScreeningEditorWindow
            {
                DataContext = _mainViewModel
            };
            _screeningEditorView.ShowDialog();
        }

        private void _mainViewModel_FinishingScreeningEdit(object sender, EventArgs e)
        {
            if (_screeningEditorView.IsActive)
            {
                _screeningEditorView.Close();
            }
        }

        //Add
        private void _mainViewModel_StartingScreeningCreate(object sender, EventArgs e)
        {
            _screeningCreatorView = new ScreeningCreatorWindow
            {
                DataContext = _mainViewModel
            };
            _screeningCreatorView.ShowDialog();
        }

        private void _mainViewModel_FinishingScreeningCreate(object sender, EventArgs e)
        {
            if (_screeningCreatorView.IsActive)
            {
                _screeningCreatorView.Close();
            }
        }

        #endregion

        #region Seat methods

        private void _mainViewModel_StartingSeatEdit(object sender, EventArgs e)
        {
            _seatEditorView = new SeatEditorWindow
            {
                DataContext = _mainViewModel
            };
            _seatEditorView.ShowDialog();
        }

        private void _mainViewModel_FinishingSeatEdit(object sender, EventArgs e)
        {
            if (_seatEditorView.IsActive)
            {
                _seatEditorView.Close();
            }
        }

        #endregion
    }
}
