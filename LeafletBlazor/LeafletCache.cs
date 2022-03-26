using LeafletBlazor.Models;
using Microsoft.JSInterop;
using System.Collections.Concurrent;

namespace LeafletBlazor
{
    internal class LeafletCache
    {
        ConcurrentDictionary<string, (IDisposable, string, Layer)> LayerReferences { get; } = new ConcurrentDictionary<string, (IDisposable, string, Layer)>();

        public ValueTask Create(IJSRuntime jsRuntime, LeafletBlazorMap map) =>
            jsRuntime.InvokeVoidAsync($"{Utils._BaseMapObject}.create", map, DotNetObjectReference.Create(map));

        internal DotNetObjectReference<T> CreateLayerReference<T>(string mapId, T layer) where T : Layer
        {
            var result = DotNetObjectReference.Create(layer);
            LayerReferences.TryAdd(layer.Id, (result, mapId, layer));
            return result;
        }

        internal void DisposeLayerReference(string layerId)
        {
            if (LayerReferences.TryRemove(layerId, out var value))
                value.Item1.Dispose();
        }
    }
}
