using System;
using System.Threading.Tasks;
using Hara.Abstractions;
using Xamarin.Essentials;

namespace Hara.XamarinCommon.Services
{
    public class WebsiteLauncher : IWebsiteLauncher
    {
        public async Task Launch(Uri uri)
        {
            await Browser.OpenAsync(uri);
        }
    }
}