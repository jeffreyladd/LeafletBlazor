using LeafletBlazor.Models;
using Microsoft.JSInterop;
using System.Collections.Concurrent;

namespace LeafletBlazor
{
    internal static class LeafletInterops
    {
        static ConcurrentDictionary<string, (IDisposable, string, Layer)> LayerReferences { get; }
            = new ConcurrentDictionary<string, (IDisposable, string, Layer)>();

        static readonly string _BaseObjectContainer = "window.leafletBlazor";

        public static ValueTask Create(IJSRuntime jsRuntime, LeafletBlazorMap map) =>
            jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.create", map, DotNetObjectReference.Create(map));

        private static DotNetObjectReference<T> CreateLayerReference<T>(string mapId, T layer) where T : Layer
        {
            var result = DotNetObjectReference.Create(layer);
            LayerReferences.TryAdd(layer.Id, (result, mapId, layer));
            return result;
        }

        private static void DisposeLayerReference(string layerId)
        {
            if (LayerReferences.TryRemove(layerId, out var value))
                value.Item1.Dispose();
        }

        internal static class Map
        {
            internal static ValueTask AddLayer(IJSRuntime jsRuntime, string mapId, Layer layer)
            {
                return layer switch
                {
                    TileLayer tileLayer => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addTilelayer", mapId, tileLayer, CreateLayerReference(mapId, tileLayer)),
                    //MbTilesLayer mbTilesLayer => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addMbTilesLayer", mapId, mbTilesLayer, CreateLayerReference(mapId, mbTilesLayer)),
                    //ShapefileLayer shapefileLayer => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addShapefileLayer", mapId, shapefileLayer, CreateLayerReference(mapId, shapefileLayer)),
                    //Marker marker => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addMarker", mapId, marker, CreateLayerReference(mapId, marker)),
                    //Rectangle rectangle => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addRectangle", mapId, rectangle, CreateLayerReference(mapId, rectangle)),
                    //Circle circle => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addCircle", mapId, circle, CreateLayerReference(mapId, circle)),
                    //Polygon polygon => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addPolygon", mapId, polygon, CreateLayerReference(mapId, polygon)),
                    //Polyline polyline => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addPolyline", mapId, polyline, CreateLayerReference(mapId, polyline)),
                    //ImageLayer image => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addImageLayer", mapId, image, CreateLayerReference(mapId, image)),
                    //GeoJsonDataLayer geo => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addGeoJsonLayer", mapId, geo, CreateLayerReference(mapId, geo)),
                    _ => throw new NotImplementedException($"The layer {typeof(Layer).Name} has not been implemented."),
                };
            }

            internal static async ValueTask RemoveLayer(IJSRuntime jsRuntime, string mapId, string layerId)
            {
                await jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.removeLayer", mapId, layerId);
                DisposeLayerReference(layerId);
            }

            internal static ValueTask SetMapView(IJSRuntime jsRuntime, string mapId, LatLng center, double zoom, ZoomPanOptions options) => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.setMapView", mapId, center, zoom, options);

            internal static ValueTask SetMapZoom(IJSRuntime jsRuntime, string mapId, double zoom, ZoomPanOptions options) => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.setMapZoom", mapId, zoom, options);

            internal static ValueTask SetZoomIn(IJSRuntime jSRuntime, string mapId, double delta, ZoomOptions options) => jSRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.setZoomIn", mapId, delta, options);

            internal static ValueTask SetZoomOut(IJSRuntime jSRuntime, string mapId, double delta, ZoomOptions options) => jSRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.setZoomOut", mapId, delta, options);

            internal static ValueTask SetZoomAround(IJSRuntime jsRuntime, string mapId, LatLng center, double zoom, ZoomOptions options) => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.setZoomAround", mapId, center, zoom, options);

            internal static ValueTask SetMinZoom(IJSRuntime jSRuntime, string mapId, double zoom) => jSRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.setMinZoom", mapId, zoom);

            internal static ValueTask SetMaxZoom(IJSRuntime jSRuntime, string mapId, double zoom) => jSRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.setMaxZoom", mapId, zoom);

            internal static ValueTask PanInside(IJSRuntime jSRuntime, string mapId, LatLng latLng) => jSRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.panInside", mapId, latLng);

            internal static ValueTask InvalidateSize(IJSRuntime jSRuntime, string mapId, ZoomPanOptions options) => jSRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.InvalidateSize", mapId, options);

            internal static ValueTask Stop(IJSRuntime jSRuntime, string mapId) => jSRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.stop", mapId);

            internal static ValueTask Remove(IJSRuntime jSRuntime, string mapId) => jSRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.remove", mapId);

            internal static ValueTask<LatLng> GetCenter(IJSRuntime jsRuntime, string mapId) => jsRuntime.InvokeAsync<LatLng>($"{_BaseObjectContainer}.getCenter", mapId);

            internal static ValueTask<double> GetZoom(IJSRuntime jsRuntime, string mapId) => jsRuntime.InvokeAsync<double>($"{_BaseObjectContainer}.getZoom", mapId);

            internal static ValueTask<double> GetMinZoom(IJSRuntime jsRuntime, string mapId) => jsRuntime.InvokeAsync<double>($"{_BaseObjectContainer}.getMinZoom", mapId);

            internal static ValueTask<double> GetMaxZoom(IJSRuntime jsRuntime, string mapId) => jsRuntime.InvokeAsync<double>($"{_BaseObjectContainer}.getMaxZoom", mapId);
        }




    }
}
