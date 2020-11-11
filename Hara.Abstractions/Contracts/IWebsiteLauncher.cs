using System;
using System.Threading.Tasks;

namespace Hara.Abstractions
{
    public interface IWebsiteLauncher
    {
        Task Launch(Uri uri);
    }
}