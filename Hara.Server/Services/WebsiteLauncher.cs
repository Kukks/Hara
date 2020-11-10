using System;
using System.Threading.Tasks;
using Hara.Abstractions;
using Microsoft.JSInterop;

namespace Hara.Server.Services
{
    public class WebsiteLauncher : IWebsiteLauncher
    {
        private readonly IJSRuntime _jsRuntime;

        public WebsiteLauncher(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        public async Task Launch(Uri uri)
        {
            await _jsRuntime.InvokeAsync<object>("open", uri.ToString(), "_blank");
        }
    }
}