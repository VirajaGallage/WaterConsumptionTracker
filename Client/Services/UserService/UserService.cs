using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using WaterConsumptionTracker.Client.Pages;

namespace WaterConsumptionTracker.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public UserService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<UsersManagement> User { get ; set; } = new List<UsersManagement>();
        public List<WaterRecords> WaterRecords { get; set; } = new List<WaterRecords>();

        public async Task CreateUser(UsersManagement user)
        {
            var result = await _http.PostAsJsonAsync("api/user", user);
            await SetUsers(result);
        }

        private async Task SetUsers(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<UsersManagement>>();
            User = response;
            _navigationManager.NavigateTo("Users");
        }

        public async Task DeleteUser(int id)
        {
            var result = await _http.DeleteAsync($"api/user/{id}");
            var response = await result.Content.ReadFromJsonAsync<List<UsersManagement>>();
            await SetUsers(result);
        }

        public async Task<UsersManagement> GetSingleUser(int id)
        {
            var result = await _http.GetFromJsonAsync<UsersManagement>($"api/user/{id}");
            if (result != null)
                return result; 
            throw new Exception("User cannot be found!");
        }

        public async Task GetUsers()
        {
            var results = await _http.GetFromJsonAsync<List<UsersManagement>>("api/user");
            if (results != null)
                User = results;
        }

        public async Task  GetWaterRecords()
        {
            var results = await _http.GetFromJsonAsync<List<WaterRecords>>("api/user");
            if (results != null)
                WaterRecords = results;
        }

        public async Task UpdateUser(UsersManagement user)
        {
            var result = await _http.PutAsJsonAsync($"api/user/{user.Id}", user);
            await SetUsers(result);
        }

        public async Task<WaterRecords> GetWaterRecordsforUser(int id)
        {
            var result = await _http.GetFromJsonAsync<WaterRecords>($"api/user/{id}");
            if (result != null)
                return result;
            throw new Exception("User cannot be found!");
        }
    }
}
