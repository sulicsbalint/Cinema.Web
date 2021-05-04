using Cinema.Desktop.Model;
using Cinema.Desktop.View;
using Cinema.Desktop.ViewModel;
using System;
using System.Configuration;
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
            _mainViewModel.LogoutSucceeded += _mainViewModel_LogoutSucceeded;
            _mainViewModel.MessageApplication += onMessageApplication;

            _mainView = new MainWindow
            {
                DataContext = _mainViewModel
            };

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
    }
}
