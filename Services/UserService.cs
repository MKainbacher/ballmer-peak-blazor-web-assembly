using ballmer_peak_web_assembly.Model;
using System.Net.Http.Json;

namespace ballmer_peak_web_assembly.Services;

public class UserService
{
    private HttpClient httpClient;

    public UserService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        IEnumerable<User>? users = await httpClient.GetFromJsonAsync<IEnumerable<User>>("https://jsonplaceholder.typicode.com/users");

        return users ?? Enumerable.Empty<User>();
    }

    public Task<User?> GetByIdAsync(string id)
    {
        return httpClient.GetFromJsonAsync<User>($"https://jsonplaceholder.typicode.com/users/{id}");
    }
}
