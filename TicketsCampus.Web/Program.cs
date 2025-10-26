using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TicketsCampus.Service.Interoperability;
using TicketsCampus.Service.Interoperability.TicketsAgreement.Methods;
using TicketsCampus.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

using var http = new HttpClient();
http.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);

var config = await http.GetFromJsonAsync<Dictionary<string, string>>("appsettings.json");
var apiBaseUrl = config?["ApiBaseUrl"] ?? "https://localhost:7290/";

builder.Services.AddHttpClient<GeneralConfigurationService>(client => { client.BaseAddress = new Uri(apiBaseUrl); });

builder.Services.AddScoped<TicketService>();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(apiBaseUrl)
});

await builder.Build().RunAsync();