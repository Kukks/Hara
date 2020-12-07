using BlazorTransitionableRoute;
using Microsoft.Extensions.DependencyInjection;

namespace Hara.UI.Services
{
    public static class UIServiceExtensions
    {
        public static IServiceCollection AddUIServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<UIStateService>();
            serviceCollection.AddScoped<BlazorTransitionableRoute.IRouteTransitionInvoker, DefaultRouteTransitionInvoker>();

            return serviceCollection;
        }
    }
}