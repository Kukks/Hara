using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Hara.Abstractions;

namespace Hara.WASM.Services
{
    public class WeatherForecastFetcher : IWeatherForecastFetcher
    {
        private readonly HttpClient _httpClient;

        public WeatherForecastFetcher(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<WeatherForecast>> Fetch()
        {
            // The static web asset is loaded from the wwwroot from _content/<AssemblyOrNugetName>/weather.json
            // see https://docs.microsoft.com/aspnet/core/razor-pages/ui-class?view=aspnetcore-3.1&tabs=visual-studio#consume-content-from-a-referenced-rcl for more info

            var fileInfo = await _httpClient.GetAsync("_content/Hara.UI/weather.json");
            fileInfo.EnsureSuccessStatusCode();
            return await JsonSerializer.DeserializeAsync<WeatherForecast[]>(await fileInfo.Content.ReadAsStreamAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}