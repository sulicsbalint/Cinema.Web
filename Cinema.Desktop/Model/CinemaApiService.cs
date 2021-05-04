using Cinema.Persistence.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cinema.Desktop.Model
{
    public class CinemaApiService
    {
        #region Fields

        private readonly HttpClient _client;

        #endregion

        #region Constructor

        public CinemaApiService(string baseAddress)
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri(baseAddress)
            };
        }

        #endregion

        #region Services

        public async Task<bool> LoginAsync(string userName, string password)
        {
            LoginDto user = new LoginDto
            {
                UserName = userName,
                Password = password
            };

            var response = await _client.PostAsJsonAsync("api/Account/Login", user);

            if (response.IsSuccessStatusCode)
                return true;
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return false;

            throw new NetworkException("Service returned response: " + response.StatusCode);
        }

        public async Task LogoutAsync()
        {
            HttpResponseMessage response = await _client.PostAsync("api/Account/Logout", null);

            if (response.IsSuccessStatusCode)
            {
                return;
            }

            throw new NetworkException("Service returned response: " + response.StatusCode);
        }

        public async Task<IEnumerable<MovieDto>> LoadMoviesAsync()
        {
            var response = await _client.GetAsync("api/Movies");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<MovieDto>>();
            }

            throw new NetworkException("Service returned response: " + response.StatusCode);
        }

        public async Task<IEnumerable<ScreeningDto>> LoadScreeningsAsync(int movieId)
        {
            var response = await _client.GetAsync($"api/Screenings/Movie/{movieId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<ScreeningDto>>();
            }

            throw new NetworkException("Service returned response: " + response.StatusCode);
        }

        #endregion
    }
}
