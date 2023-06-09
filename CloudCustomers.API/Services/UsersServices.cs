using CloudCustomers.API.Models;

namespace CloudCustomers.API.Services
{
    public interface IUsersServices
    {
        Task<List<User>> GetUsers();
    }
    public class UsersServices : IUsersServices
    {
        private readonly HttpClient _httpClient;

        public UsersServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetUsers()
        {
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<User>();
            }

            var responseContent = response.Content;
            var allUsers = await responseContent.ReadFromJsonAsync<List<User>>();
            return allUsers.ToList();

        }
    }
}
