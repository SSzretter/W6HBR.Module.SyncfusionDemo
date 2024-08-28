using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace W6HBR.Module.SyncfusionDemo
{
    public class Interop
    {
        private readonly IJSRuntime _jsRuntime;

        public Interop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
    }
}
