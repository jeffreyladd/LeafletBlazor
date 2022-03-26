using Microsoft.JSInterop;

namespace LeafletBlazor.Models
{
    public class WmsLayer : GridLayer
    {
        public WmsLayer(WmsLayerOptions options) : base() { this.Options = options; }

        public WmsLayerOptions Options { get; private set; }

        /// <summary>
        /// Updates the layer's URL template and redraws it (unless noRedraw is set to true). If the URL does not change, the layer will not be redrawn unless the noRedraw parameter is set to false.
        /// </summary>
        /// <param name="url">The url to be used.</param>
        /// <param name="noRedraw">If leaflet should redraw the layer.</param>
        /// <returns></returns>
        public ValueTask SetUrl(string url, bool? noRedraw) => this._JSRuntime.InvokeVoidAsync($"{Utils._BaseTileLayerObject}.setUrl", this.Id, this._Map.Id, url, noRedraw);
    }
}
