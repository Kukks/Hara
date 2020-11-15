using System.Text.Json;
using System.Threading.Tasks;
using Hara.Abstractions.Contracts;
using Microsoft.JSInterop;

namespace Hara.WebCommon
{
    public class JsInteropConfigProvider : IConfigProvider
    {
        private readonly IJSRuntime _jsRuntime;

        public JsInteropConfigProvider(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<T> Get<T>(string key)
        {
            var lsRes = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);

            if (lsRes is null)
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(lsRes);
        }

        public async Task Set<T>(string key, T value)
        {
            if (value.Equals(default(T)))
            {
                await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
            }
            else
            {
                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, JsonSerializer.Serialize(value));
            }
        }
    }
}