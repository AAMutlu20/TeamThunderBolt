using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EduAssignmentHub.Services;

public class AuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> LoginAsync(string username, string password)
    {
        var loginModel = new { Username = username, Password = password };
        var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginModel);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadAsStringAsync();
        return result;
    }
}