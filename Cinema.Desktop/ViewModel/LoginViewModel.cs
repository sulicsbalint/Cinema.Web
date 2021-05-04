using Cinema.Desktop.Model;
using System;
using System.Net.Http;
using System.Windows.Controls;

namespace Cinema.Desktop.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        #region Fields

        private readonly CinemaApiService _service;

        #endregion

        #region Commands

        public DelegateCommand LoginCommand { get; set; }

        #endregion

        #region Properties

        public Boolean IsLoading { get; set; }
        public String UserName { get; set; }

        #endregion

        #region Events

        public event EventHandler LoginSucceeded;
        public event EventHandler LoginFailed;

        #endregion

        #region Constructor
        
        public LoginViewModel(CinemaApiService service)
        {
            _service = service;
            IsLoading = false;

            LoginCommand = new DelegateCommand(_ => !IsLoading, param => LoginAsync(param as PasswordBox));
        }

        #endregion

        #region Methods

        private async void LoginAsync(PasswordBox passwordBox)
        {
            try
            {
                IsLoading = true;
                Boolean result = await _service.LoginAsync(UserName, passwordBox.Password);

                if (result)
                    LoginSucceeded?.Invoke(this, EventArgs.Empty);
                else
                    LoginFailed?.Invoke(this, EventArgs.Empty);

            }
            catch (Exception ex) when (ex is NetworkException || ex is HttpRequestException)
            {
                OnMessageApplication($"Unexpected error occured! ({ex.Message})");
            }
            finally
            {
                IsLoading = false;
            }
        }

        #endregion
    }
}
