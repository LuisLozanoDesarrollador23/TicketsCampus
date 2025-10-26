using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace TicketsCampus.Service.Interoperability;

public class GeneralConfigurationService
{
    private readonly HttpClient _http;

    public GeneralConfigurationService(HttpClient http)
    {
        _http = http;
    }

    public async Task<TResponse?> PostAsJsonAsync<TRequest, TResponse>(string relativeUrl,
        TRequest data)
    {
        var json = JsonSerializer.Serialize(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var request = new HttpRequestMessage(new HttpMethod("POST"), relativeUrl)
        {
            Content = content
        };

        var response = await _http.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TResponse>();
    }

    public Task<T?> GetFromJsonAsync<T>(string relativeUrl)
    {
        return _http.GetFromJsonAsync<T>(relativeUrl);
    }

    public async Task<TResponse?> PatchAsJsonAsync<TRequest, TResponse>(string relativeUrl,
        TRequest data)
    {
        var json = JsonSerializer.Serialize(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var request = new HttpRequestMessage(new HttpMethod("PATCH"), relativeUrl)
        {
            Content = content
        };

        var response = await _http.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TResponse>();
    }
}