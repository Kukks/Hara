using System.Text.Json;
using System.Threading.Tasks;
using Hara.Abstractions.Contracts;
using Xamarin.Essentials;

namespace Hara.XamarinCommon.Services
{
    public class XamarinEssentialsSecureConfigProvider : ISecureConfigProvider
    {
        public Task<T> Get<T>(string key)
        {
            return Task.FromResult(SecureStorage.ContainsKey(key)
                ? JsonSerializer.Deserialize<T>(SecureStorage.Get(key, ""))
                : default);
        }

        public Task Set<T>(string key, T value)
        {
            if (value.Equals(default(T)))
            {
                SecureStorage.Remove(key);
            }
            else
            {
                SecureStorage.Set(key, JsonSerializer.Serialize(value));
            }

            return Task.CompletedTask;
            ;
        }
    }
}