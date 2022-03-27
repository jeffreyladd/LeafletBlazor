using LeafletBlazor.EventHandlers;
using Microsoft.JSInterop;

namespace LeafletBlazor.Models
{
    public class ImageOverlayLayer : InteractiveLayer
    {
        public ImageOverlayLayer(ImageOverlayOptions options) : base() { this.Options = options; }

        public ImageOverlayOptions Options { get; private set; }

        public delegate void ImageOverlayLayerEventHandler(object sender, Event e);

        // <summary>
        /// Fired when the ImageOverlay layer has loaded its image.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event ImageOverlayLayerEventHandler OnLoad;

        [JSInvokable]
        public void NotifyLoad(Event e) => OnLoad?.Invoke(this, e);

        /// <summary>
        /// Fired when the ImageOverlay layer fails to load its image
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event ImageOverlayLayerEventHandler OnError;

        [JSInvokable]
        public void NotifyError(Event e) => OnError?.Invoke(this, e);

        /// <summary>
        /// Brings the tile layer to the bottom of all tile layers.
        /// </summary>
        /// <param name="op">THe opacity to set</param>
        public ValueTask SetOpacity(double op) => this._JSRuntime.InvokeVoidAsync($"{Utils._BaseImageLayerObject}.setOpacity", this.Id, this._Map.Id, op);

        /// <summary>
        /// Brings the tile layer to the top of all tile layers.
        /// </summary>
        public ValueTask BringToBack() => this._JSRuntime.InvokeVoidAsync($"{Utils._BaseImageLayerObject}.bringToBack", this.Id, this._Map.Id);

        /// <summary>
        /// Brings the tile layer to the bottom of all tile layers.
        /// </summary>
        public ValueTask BringToFront() => this._JSRuntime.InvokeVoidAsync($"{Utils._BaseImageLayerObject}.bringToFront", this.Id, this._Map.Id);

        /// <summary>
        /// Changes the URL of the Image.
        /// </summary>
        /// <param name="url">The URL to change to.</param>
        /// <returns></returns>
        public ValueTask SetUrl(string url) => this._JSRuntime.InvokeVoidAsync($"{Utils._BaseImageLayerObject}.setUrl", this.Id, this._Map.Id, url);

        /// <summary>
        /// Update the bounds that this ImageOverlay covers
        /// </summary>
        /// <param name="bounds"></param>
        /// <returns></returns>
        public ValueTask SetBounds(LatLngBounds bounds) => this._JSRuntime.InvokeVoidAsync($"{Utils._BaseImageLayerObject}.setBounds", this.Id, this._Map.Id, bounds);

        /// <summary>
        /// Changes the zIndex of the grid layer.
        /// </summary>
        /// <param name="zIndex">The zIndex to set</param>
        public ValueTask SetZIndex(int zIndex) => this._JSRuntime.InvokeVoidAsync($"{Utils._BaseImageLayerObject}.setZIndex", this.Id, this._Map.Id, zIndex);

        /// <summary>
        /// Get the bounds that this ImageOverlay covers
        /// </summary>
        /// <returns></returns>
        public ValueTask<LatLngBounds> GetBounds() => this._JSRuntime.InvokeAsync<LatLngBounds>($"{Utils._BaseImageLayerObject}.getBounds", this.Id, this._Map.Id);

        //TODO: Do getElement
    }
}
