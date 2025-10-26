using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace TicketsCampus.Service.Interoperability;

/// <summary>
///     Permite la configuración de los metodos genericos rest para utilizar en los servicios de las entidades
/// </summary>
public class GeneralConfigurationService
{
    private readonly HttpClient _http;

    public GeneralConfigurationService(HttpClient http)
    {
        _http = http;
    }

    /// <summary>
    ///     Permite suministrar el metodo post a los servicios de las entidades
    /// </summary>
    /// <param name="relativeUrl">Nombre del endpoint al cual se va a conectar</param>
    /// <param name="data">Objeto generico que se debe suministrar (el tipo se indica en la declaración del metodo en el servicio)</param>
    /// <typeparam name="TRequest">Tipo de datos que se debe sumunistrar</typeparam>
    /// <typeparam name="TResponse">Tipo de dato que va a devolver el metodo</typeparam>
    /// <returns>Objeto de respuesta, según el tipo establecido</returns>
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

    /// <summary>
    ///     Permite suministrar el metodo get a los servicios de las entidades
    /// </summary>
    /// <param name="relativeUrl">Nombre del endpoint al cual se va a conectar</param>
    /// <typeparam name="T">Tipo de dato que va a devolver el metodo</typeparam>
    /// <returns>Objeto según el tipo de dato establecido en la declaración del metodo</returns>
    public Task<T?> GetFromJsonAsync<T>(string relativeUrl)
    {
        return _http.GetFromJsonAsync<T>(relativeUrl);
    }

    /// <summary>
    ///     Permite suministrar el metodo patch a los servicios de las entidades
    /// </summary>
    /// <param name="relativeUrl">Nombre del endpoint al cual se va a conectar</param>
    /// <param name="data">Objeto generico que se debe suministrar (el tipo se indica en la declaración del metodo en el servicio)</param>
    /// <typeparam name="TRequest">Tipo de datos que se debe sumunistrar</typeparam>
    /// <typeparam name="TResponse">Tipo de dato que va a devolver el metodo</typeparam>
    /// <returns>Objeto de respuesta, según el tipo establecido</returns>
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