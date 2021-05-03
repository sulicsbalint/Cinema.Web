using Cinema.Desktop.Model;
using Cinema.Desktop.View;
using Cinema.Desktop.ViewModel;
using System.Configuration;
using System.Windows;

namespace Cinema.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private CinemaApiService _service;
        private MainViewModel _mainViewModel;
        private MainWindow _view;

        public App()
        {
            Startup += App_Startup;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            _service = new CinemaApiService(ConfigurationManager.AppSettings["baseAddress"]);

            _mainViewModel = new MainViewModel(_service);

            _view = new MainWindow
            {
                DataContext = _mainViewModel
            };

            _view.Show();
        }

        private void _mainViewModel_MessageApplication(object sender, MessageEventArgs e)
        {
            MessageBox.Show(e.Message, "Cinema", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
    }
}
