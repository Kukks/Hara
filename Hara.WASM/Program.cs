using System;
using System.Net.Http;
using System.Threading.Tasks;
using Hara.Abstractions;
using Hara.Abstractions.Services;
using Hara.UI;
using Hara.WASM.Services;
using Hara.XamarinCommon.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Hara.WASM
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddSingleton<ICounterState, CounterState>();
            builder.Services.AddSingleton<ILocalContentFetcher, HttpClientLocalContentFetcher>();
            builder.Services.AddSingleton<IWebsiteLauncher, JsInteropWebsiteLauncher>();
            builder.Services.AddSingleton<IWeatherForecastFetcher, WeatherForecastFetcher>();

            builder.Services.AddSingleton(
                sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});

            await builder.Build().RunAsync();
        }
    }
}