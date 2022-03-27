using LeafletBlazor.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.ObjectModel;
using System.Drawing;

namespace LeafletBlazor
{
    public partial class LeafletBlazorMap : ComponentBase
    {
        public LeafletBlazorMap()
        {
            this.Id = Utils.GetRandomString(12);
            this._Layers.CollectionChanged += OnLayersChanged;
            this._Cache = new LeafletCache();
        }

        /// <summary>
        /// Check for if the map has been initialized.
        /// </summary>
        bool _isInitialized = false;

        [Inject]
        public IJSRuntime JsRuntime { get; protected set; }

        internal LeafletCache _Cache { get; private set; }

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
        public IReadOnlyList<Layer> Layers => this._Layers.ToList();

        internal ObservableCollection<Layer> _Layers = new ObservableCollection<Layer>();

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

        /// <summary>
        /// Sets a map view that contains the given geographical bounds with the maximum zoom level possible.
        /// </summary>
        /// <param name="bounds">The Bounds to which set the map to.</param>
        /// <param name="options">The Options as to which set.</param>
        /// <returns></returns>
        public ValueTask FitBounds(LatLngBounds bounds, FitBoundsOptions? options) => this.JsRuntime.InvokeVoidAsync($"{Utils._BaseMapObject}.fitBounds", this.Id, bounds, options);

        /// <summary>
        /// Sets a map view that mostly contains the whole world with the maximum zoom level possible. 
        /// </summary>
        /// <param name="options">The options to pass</param>
        /// <returns></returns>
        public ValueTask FitWorld(FitBoundsOptions options) => this.JsRuntime.InvokeVoidAsync($"{Utils._BaseMapObject}.fitBounds", this.Id, options);

        /// <summary>
        /// Sets the view of the map (geographical center and zoom) performing a smooth pan-zoom animation.
        /// </summary>
        /// <param name="latlng">The point to pan to.</param>
        /// <param name="zoom">The zoom to use.</param>
        /// <param name="options">The options to pass.</param>
        /// <returns></returns>
        public ValueTask FlyTo(LatLng latlng, int? zoom, ZoomPanOptions? options) => this.JsRuntime.InvokeVoidAsync($"{Utils._BaseMapObject}.flyTo", this.Id, latlng, zoom, options);

        /// <summary>
        /// Sets the view of the map with a smooth animation like flyTo, but takes a bounds parameter like fitBounds.
        /// </summary>
        /// <param name="bounds">The bounds to set</param>
        /// <param name="options">The options to use.</param>
        /// <returns></returns>
        public ValueTask FlyToBounds(LatLngBounds bounds, FitBoundsOptions? options) => this.JsRuntime.InvokeVoidAsync($"{Utils._BaseMapObject}.flyToBounds", this.Id, bounds, options);

        /// <summary>
        /// Restricts the map view to the given bounds(see the maxBounds option).
        /// </summary>
        /// <param name="bounds">The bounds to set.</param>
        /// <returns></returns>
        public ValueTask SetMaxBounds(LatLngBounds bounds) => this.JsRuntime.InvokeVoidAsync($"{Utils._BaseMapObject}.setMaxBounds", this.Id, bounds);

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

        /// <summary>
        /// Pans the map to the closest view that would lie inside the given bounds (if it's not already), controlling the animation using the options specific, if any.
        /// </summary>
        /// <param name="bounds">The bounds to set.</param>
        /// <param name="options">The options to set.</param>
        /// <returns></returns>
        public ValueTask PanInsideBounds(LatLngBounds bounds, ZoomPanOptions? options) => this.JsRuntime.InvokeVoidAsync($"{Utils._BaseMapObject}.panInsideBounds", this.Id, bounds, options);

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

        /// <summary>
        /// Returns the geographical bounds visible in the current map view
        /// </summary>
        /// <returns></returns>
        public ValueTask<LatLngBounds> GetBounds() => this.JsRuntime.InvokeAsync<LatLngBounds>($"{Utils._BaseMapObject}.getBounds", this.Id);

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

        /// <summary>
        /// Returns the maximum zoom level on which the given bounds fit to the map view in its entirety. If inside (optional) is set to true, the method instead returns the minimum zoom level on which the map view fits into the given bounds in its entirety.
        /// </summary>
        /// <param name="bounds">The bounds in which to use.</param>
        /// <param name="inside"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public ValueTask<double> GetBoundsZoom(LatLngBounds bounds, bool? inside, PointF? point) => this.JsRuntime.InvokeAsync<double>($"{Utils._BaseMapObject}.getBoundsZoom", this.Id, bounds, inside, point);

        //TODO: Add GetSizes, Conversion, and Evented Methods.

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

            layer._JSRuntime = this.JsRuntime;
            layer._Map = this;

            _Layers.Add(layer);
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

            _Layers.Remove(layer);
        }        
    }
}
