using Microsoft.JSInterop;
using System.Drawing;

namespace LeafletBlazor.Models
{
    /// <summary>
    /// The Tile Layer that should be used.
    /// </summary>
    public class TileLayer : GridLayer
    {
        public TileLayer(TileLayerOptions options) : base() { this.Options = options; }

        public TileLayerOptions Options { get; private set; }

        /// <summary>
        /// Updates the layer's URL template and redraws it (unless noRedraw is set to true). If the URL does not change, the layer will not be redrawn unless the noRedraw parameter is set to false.
        /// </summary>
        /// <param name="url">The url to be used.</param>
        /// <param name="noRedraw">If leaflet should redraw the layer.</param>
        /// <returns></returns>
        public ValueTask SetUrl(string url, bool? noRedraw) => this._JSRuntime.InvokeVoidAsync($"{Utils._BaseTileLayerObject}.setUrl", this.Id, this._Map.Id, url, noRedraw);
    }
}
