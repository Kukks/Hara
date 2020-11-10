using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Hara.Abstractions;
using Microsoft.Extensions.FileProviders;

namespace Hara.Server.Services
{
    public class WeatherForecastFetcher : IWeatherForecastFetcher
    {
        private readonly IFileProvider _fileProvider;

        public WeatherForecastFetcher(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }
        public async Task<IEnumerable<WeatherForecast>> Fetch()
        {
            // The static web asset is loaded from the wwwroot from _content/<AssemblyOrNugetName>/weather.json
            // see https://docs.microsoft.com/aspnet/core/razor-pages/ui-class?view=aspnetcore-3.1&tabs=visual-studio#consume-content-from-a-referenced-rcl for more info

            var fileInfo = _fileProvider.GetFileInfo("_content/Hara.UI/weather.json");
            return await JsonSerializer.DeserializeAsync<WeatherForecast[]>(fileInfo.CreateReadStream(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}