using Cinema.Desktop.Model;
using Cinema.Desktop.View;
using Cinema.Desktop.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
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
        private MovieEditorWindow _editorView;
        private MovieCreatorWindow _creatorView;

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

            _mainViewModel.StartingMovieEdit += _mainViewModel_StartingMovieEdit;
            _mainViewModel.FinishingMovieEdit += _mainViewModel_FinishingMovieEdit;
            _mainViewModel.StartingImageChange += _mainViewModel_StartingImageChange;

            _mainViewModel.StartingMovieCreate += _mainViewModel_StartingMovieCreate;
            _mainViewModel.FinishingMovieCreate += _mainViewModel_FinishingMovieCreate;
            _mainViewModel.StartingImageAdd += _mainViewModel_StartingImageAdd;

            _mainView = new MainWindow
            {
                DataContext = _mainViewModel
            };

            _mainView.Show();
            //_loginView.Show();
        }

        private void _mainViewModel_StartingMovieEdit(object sender, EventArgs e)
        {
            _editorView = new MovieEditorWindow
            {
                DataContext = _mainViewModel
            };
            _editorView.ShowDialog();
        }

        private void _mainViewModel_FinishingMovieEdit(object sender, EventArgs e)
        {
            if (_editorView.IsActive)
            {
                _editorView.Close();
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

            if (dialog.ShowDialog(_editorView).GetValueOrDefault(false))
            {
                _mainViewModel.EditableMovie.Image = await File.ReadAllBytesAsync(dialog.FileName);
            }
        }


        private void _mainViewModel_StartingMovieCreate(object sender, EventArgs e)
        {
            _creatorView = new MovieCreatorWindow
            {
                DataContext = _mainViewModel
            };
            _creatorView.ShowDialog();
        }

        private void _mainViewModel_FinishingMovieCreate(object sender, EventArgs e)
        {
            if (_creatorView.IsActive)
            {
                _creatorView.Close();
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

            if (dialog.ShowDialog(_editorView).GetValueOrDefault(false))
            {
                _mainViewModel.CreateableMovie.Image = await File.ReadAllBytesAsync(dialog.FileName);
            }
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
    }
}
