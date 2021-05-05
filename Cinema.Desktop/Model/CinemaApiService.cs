using Cinema.Desktop.ViewModel;
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

        #endregion

        #region Movie services

        public async Task<IEnumerable<MovieViewModel>> LoadMoviesAsync()
        {
            var response = await _client.GetAsync("api/Movies");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<MovieViewModel>>();
            }

            throw new NetworkException("Service returned response: " + response.StatusCode);
        }

        public async Task CreateMovieAsync(MovieDto movie)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync($"api/Movies", movie);
            movie.Id = (await response.Content.ReadAsAsync<MovieDto>()).Id;

            if (!response.IsSuccessStatusCode)
            {
                throw new NetworkException("Service returned response: " + response.StatusCode);
            }
        }

        public async Task UpdateMovieAsync(MovieDto movie)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync($"api/movies/{movie.Id}", movie);

            if (!response.IsSuccessStatusCode)
            {
                throw new NetworkException("Service returned response: " + response.StatusCode);
            }
        }

        public async Task DeleteMovieAsync(Int32 movieId)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"api/movies/{movieId}");

            if (!response.IsSuccessStatusCode)
            {
                throw new NetworkException("Service returned response: " + response.StatusCode);
            }
        }

        #endregion

        #region Screening services

        public async Task<IEnumerable<ScreeningViewModel>> LoadScreeningsAsync(int movieId)
        {
            var response = await _client.GetAsync($"api/Screenings/Movie/{movieId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<ScreeningViewModel>>();
            }

            throw new NetworkException("Service returned response: " + response.StatusCode);
        }

        public async Task CreateScreeningAsync(ScreeningDto screening)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("api/Screenings/", screening);
            screening.Id = (await response.Content.ReadAsAsync<ScreeningDto>()).Id;

            if (!response.IsSuccessStatusCode)
            {
                throw new NetworkException("Service returned response: " + response.StatusCode);
            }
        }

        public async Task UpdateScreeningAsync(ScreeningDto screening)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync($"api/Screenings/{screening.Id}", screening);

            if (!response.IsSuccessStatusCode)
            {
                throw new NetworkException("Service returned response: " + response.StatusCode);
            }
        }

        public async Task DeleteScreeningAsync(Int32 screeningId)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"api/Screenings/{screeningId}");

            if (!response.IsSuccessStatusCode)
            {
                throw new NetworkException("Service returned response: " + response.StatusCode);
            }
        }

        #endregion

        #region Room service

        public async Task<IEnumerable<RoomViewModel>> LoadRoomsAsync()
        {
            var response = await _client.GetAsync("api/Movies");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<RoomViewModel>>();
            }

            throw new NetworkException("Service returned response: " + response.StatusCode);
        }

        #endregion
    }
}
