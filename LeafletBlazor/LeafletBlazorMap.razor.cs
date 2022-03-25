using LeafletBlazor.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.ObjectModel;

namespace LeafletBlazor
{
    public partial class LeafletBlazorMap : ComponentBase
    {
        public LeafletBlazorMap()
        {
            this.Id = Utils.GetRandomString(12);
            this._layers.CollectionChanged += OnLayersChanged;
        }

        /// <summary>
        /// Check for if the map has been initialized.
        /// </summary>
        bool _isInitialized = false;

        [Inject]
        public IJSRuntime JsRuntime { get; protected set; }
        
        /// <summary>
        /// The Identifier of the map to be refrenced as.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// The options to be passed to leaflet.
        /// </summary>
        [Parameter]
        public MapOptions Options { get; set; }

        /// <summary>
        /// The List of Layers used by the map.
        /// </summary>
        public IReadOnlyList<Layer> Layers => this._layers.ToList();

        internal ObservableCollection<Layer> _layers = new ObservableCollection<Layer>();

        //TODO: Add Methods for Layers and Controls.

        /// <summary>
        /// Sets the view of the map (geographical center and zoom) with the given animation options.
        /// </summary>
        /// <param name="center">The Center point of the map</param>
        /// <param name="zoom">The Zoom to use.</param>
        /// <param name="options">The Zoom/Pan options to use when moving.</param>
        public ValueTask SetView(LatLng center, double zoom, ZoomPanOptions options) => this.JsRuntime.InvokeVoidAsync($"{Utils._BaseMapObject}.setMapView", this.Id, center, zoom, options);

        /// <summary>
        /// Sets the zoom of the map.
        /// </summary>
        /// <param name="zoom">The Zoom to use.</param>
        /// <param name="options">The Zoom/Pan options to use when moving.</param>
        public ValueTask SetZoom(double zoom, ZoomPanOptions options) => this.JsRuntime.InvokeVoidAsync($"{Utils._BaseMapObject}.setMapZoom", this.Id, zoom, options);

        /// <summary>
        /// Increases the zoom of the map by delta (zoomDelta by default).
        /// </summary>
        /// <param name="delta"></param>
        /// /// <param name="options"></param>
        public ValueTask SetZoomIn(double delta, ZoomOptions options) => this.JsRuntime.InvokeVoidAsync($"{Utils._BaseMapObject}.setZoomIn", this.Id, delta, options);

        /// <summary>
        /// Decreases the zoom of the map by delta (zoomDelta by default).
        /// </summary>
        /// <param name="delta"></param>
        /// <param name="options"></param>
        public ValueTask SetZoomOut(double delta, ZoomOptions options) => this.JsRuntime.InvokeVoidAsync($"{Utils._BaseMapObject}.setZoomOut", this.Id, delta, options);

        /// <summary>
        /// Zooms the map while keeping a specified geographical point on the map stationary (e.g. used internally for scroll zoom and double-click zoom).
        /// </summary>
        /// <param name="center">The Center point of the map</param>
        /// <param name="zoom">The Zoom to use.</param>
        /// <param name="options">The Zoom options to use when moving.</param>
        public ValueTask SetZoomAround(LatLng center, double zoom, ZoomOptions options) => this.JsRuntime.InvokeVoidAsync($"{Utils._BaseMapObject}.setZoomAround", this.Id, center, zoom, options);

        //TODO: flyToBounds, setMaxBounds

        /// <summary>
        /// Sets the lower limit for the available zoom levels (see the minZoom option).
        /// </summary>
        /// <param name="zoom">The amount to zoom out</param>
        public ValueTask SetMinZoom(double zoom) => this.JsRuntime.InvokeVoidAsync($"{Utils._BaseMapObject}.setMinZoom", this.Id, zoom);

        /// <summary>
        /// Sets the upper limit for the available zoom levels (see the maxZoom option).
        /// </summary>
        /// <param name="zoom">The amount to zoom in</param>
        public ValueTask SetMaxZoom(double zoom) => this.JsRuntime.InvokeVoidAsync($"{Utils._BaseMapObject}.setMaxZoom", this.Id, zoom);

        //TODO: panInsideBounds

        /// <summary>
        /// Pans the map the minimum amount to make the latlng visible. Use padding, paddingTopLeft and paddingTopRight options to fit the display to more restricted bounds, like fitBounds. If latlng is already within the (optionally padded) display bounds, the map will not be panned.
        /// </summary>
        /// <param name="latLng">The point to pan to.</param>
        public ValueTask PanInside(LatLng latLng) => this.JsRuntime.InvokeVoidAsync($"{Utils._BaseMapObject}.panInside", this.Id, latLng);

        /// <summary>
        /// Checks if the map container size changed and updates the map if so — call it after you've changed the map size dynamically, also animating pan by default. If options.pan is false, panning will not occur. If options.debounceMoveend is true, it will delay moveend event so that it doesn't happen often even if the method is called many times in a row.
        /// </summary>
        /// <param name="options">The options to pass.</param>
        public ValueTask InvalidateSize(ZoomPanOptions options) => this.JsRuntime.InvokeVoidAsync($"{Utils._BaseMapObject}.InvalidateSize", this.Id, options);

        /// <summary>
        /// Stops the currently running panTo or flyTo animation, if any.
        /// </summary>
        public ValueTask Stop() => this.JsRuntime.InvokeVoidAsync($"{Utils._BaseMapObject}.stop", this.Id);

        //TODO: Geolocation methods and AddHandler Methods.

        /// <summary>
        /// 
        /// </summary>
        public ValueTask Remove() => this.JsRuntime.InvokeVoidAsync($"{Utils._BaseMapObject}.remove", this.Id);

        //TODO: Add Pane Methods.

        /// <summary>
        /// Returns the geographical center of the map view
        /// </summary>
        /// <returns></returns>
        public ValueTask<LatLng> GetCenter() => this.JsRuntime.InvokeAsync<LatLng>($"{Utils._BaseMapObject}.getCenter", this.Id);

        /// <summary>
        /// Returns the current zoom level of the map view
        /// </summary>
        /// <returns></returns>
        public ValueTask<double> GetZoom() => this.JsRuntime.InvokeAsync<double>($"{Utils._BaseMapObject}.getZoom", this.Id);

        //TODO: Add GetBounds

        /// <summary>
        /// Returns the minimum zoom level of the map (if set in the minZoom option of the map or of any layers), or 0 by default.
        /// </summary>
        /// <returns></returns>
        public ValueTask<double> GetMinZoom() => this.JsRuntime.InvokeAsync<double>($"{Utils._BaseMapObject}.getMinZoom", this.Id);

        /// <summary>
        /// Returns the maximum zoom level of the map (if set in the maxZoom option of the map or of any layers).
        /// </summary>
        /// <returns></returns>
        public ValueTask<double> GetMaxZoom() => this.JsRuntime.InvokeAsync<double>($"{Utils._BaseMapObject}.getMaxZoom", this.Id);

        //TODO: Add getBoundsZoom, Sizes, COnversion, and Evented Methods.

        /// <summary>
        /// Initializing method that MUST be called by the library.
        /// </summary>
        internal void RaiseOnInit()
        {
            this._isInitialized = true;
            this.OnInit?.Invoke();
        }

        /// <summary>
        /// Add a layer to the map.
        /// </summary>
        /// <param name="layer">The layer to be added.</param>
        /// <exception cref="System.ArgumentNullException">Throws when the layer is null.</exception>
        /// <exception cref="UninitializedMapException">Throws when the map has not been yet initialized.</exception>
        public void AddLayer(Layer layer)
        {
            if (layer is null)
            {
                throw new ArgumentNullException(nameof(layer));
            }

            if (!_isInitialized)
            {
                throw new UninitializedMapException();
            }

            _layers.Add(layer);
        }

        /// <summary>
        /// Remove a layer from the map.
        /// </summary>
        /// <param name="layer">The layer to be removed.</param>
        /// <exception cref="System.ArgumentNullException">Throws when the layer is null.</exception>
        /// <exception cref="UninitializedMapException">Throws when the map has not been yet initialized.</exception>
        public void RemoveLayer(Layer layer)
        {
            if (layer is null)
            {
                throw new ArgumentNullException(nameof(layer));
            }

            if (!_isInitialized)
            {
                throw new UninitializedMapException();
            }

            _layers.Remove(layer);
        }        
    }
}
