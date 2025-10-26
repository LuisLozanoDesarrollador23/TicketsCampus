using System.Net.Http.Json;

namespace TicketsCampus.Service.Interoperability;

public class GeneralConfigurationService
{
    private readonly HttpClient _http;

    public GeneralConfigurationService(HttpClient http)
    {
        _http = http;
    }

    public Task<T?> GetFromJsonAsync<T>(string relativeUrl)
    {
        return _http.GetFromJsonAsync<T>(relativeUrl);
    }
}