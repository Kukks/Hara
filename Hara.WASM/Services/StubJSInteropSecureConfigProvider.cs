using Hara.Abstractions.Contracts;
using Hara.WebCommon;
using Microsoft.JSInterop;

namespace Hara.WASM.Services
{
    //THIS IS NOT REALLY SECURE. ONLY HERE TO TEST STUFF
    public class StubWASMJsInteropSecureConfigProvider:JsInteropConfigProvider,ISecureConfigProvider
    {
        public StubWASMJsInteropSecureConfigProvider(IJSRuntime jsRuntime) : base(jsRuntime)
        {
        }
    }
}