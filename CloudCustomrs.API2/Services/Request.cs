using CloudCustomers.API.Models;

namespace CloudCustomrs.API2.Services
{
    public class Request
    {
        private readonly HttpClient _httpClient;

        public Request(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> MakeRequest()
        {
            var response = await _httpClient.GetAsync("/Users");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadFromJsonAsync<List<User>>();
            return content;
        }

    }
}
