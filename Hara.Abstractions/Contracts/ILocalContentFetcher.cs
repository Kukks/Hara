using System.IO;
using System.Threading.Tasks;

namespace Hara.Abstractions
{
    public interface ILocalContentFetcher
    {
        Task<Stream> Fetch(string path);
    }
}