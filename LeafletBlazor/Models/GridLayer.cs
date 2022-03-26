using LeafletBlazor.EventHandlers;
using Microsoft.JSInterop;
using System.Drawing;

namespace LeafletBlazor.Models
{
    public abstract class GridLayer: Layer
    {
        public delegate void TileEventHandler(GridLayer sender, TileEvent e);

        /// <summary>
        /// Fired when the grid layer starts loading tiles.
        /// </summary>
        public event EventHandler OnLoading;

        [JSInvokable]
        public void NotifyLoading(Event eventArgs)
        {
            this.OnLoading?.Invoke(this, eventArgs);
        }

        /// <summary>
        /// Fired when a tile is removed (e.g. when a tile goes off the screen).
        /// </summary>
        public event TileEventHandler OnTileUnload;

        [JSInvokable]
        public void NotifyTileUnload(TileEvent eventArgs)
        {
            this.OnTileUnload?.Invoke(this, eventArgs);
        }

        /// <summary>
        /// Fired when a tile is requested and starts loading.
        /// </summary>
        public event TileEventHandler OnTileLoadStart;

        [JSInvokable]
        public void NotifyTileLoadStart(TileEvent eventArgs)
        {
            this.OnTileLoadStart?.Invoke(this, eventArgs);
        }

        public delegate void TileErrorEventHandler(GridLayer sender, TileErrorEvent e);

        /// <summary>
        /// Fired when there is an error loading a tile.
        /// </summary>
        public event TileErrorEventHandler OnTileError;

        [JSInvokable]
        public void NotifyTileError(TileErrorEvent eventArgs)
        {
            this.OnTileError?.Invoke(this, eventArgs);
        }

        /// <summary>
        /// Fired when a tile loads.
        /// </summary>
        public event TileEventHandler OnTileLoad;

        [JSInvokable]
        public void NotifyTileLoad(TileEvent eventArgs)
        {
            this.OnTileLoad?.Invoke(this, eventArgs);
        }

        /// <summary>
        /// Fired when the grid layer loaded all visible tiles.
        /// </summary>
        public event EventHandler OnLoad;

        [JSInvokable]
        public void NotifyLoad(Event eventArgs)
        {
            this.OnLoad?.Invoke(this, eventArgs);
        }

        /// <summary>
        /// Brings the tile layer to the top of all tile layers.
        /// </summary>
        public virtual ValueTask BringToBack() => this._JSRuntime.InvokeVoidAsync($"{Utils._BaseGridLayerObject}.bringToBack", this.Id, this._Map.Id);

        /// <summary>
        /// Brings the tile layer to the bottom of all tile layers.
        /// </summary>
        public virtual ValueTask BringToFront() => this._JSRuntime.InvokeVoidAsync($"{Utils._BaseGridLayerObject}.bringToFront", this.Id, this._Map.Id);

        //TODO: Do GetCOntainer

        /// <summary>
        /// Brings the tile layer to the bottom of all tile layers.
        /// </summary>
        /// <param name="op">THe opacity to set</param>
        public virtual ValueTask SetOpacity(double op) => this._JSRuntime.InvokeVoidAsync($"{Utils._BaseGridLayerObject}.setOpacity", this.Id, this._Map.Id, op);

        /// <summary>
        /// Changes the zIndex of the grid layer.
        /// </summary>
        /// <param name="zIndex">The zIndex to set</param>
        public virtual ValueTask SetZIndex(int zIndex) => this._JSRuntime.InvokeVoidAsync($"{Utils._BaseGridLayerObject}.setZIndex", this.Id, this._Map.Id, zIndex);

        /// <summary>
        /// Returns true if any tile in the grid layer has not finished loading.
        /// </summary>
        /// <returns></returns>
        public virtual ValueTask<bool> IsLoading() => this._JSRuntime.InvokeAsync<bool>($"{Utils._BaseGridLayerObject}.isLoading", this.Id, this._Map.Id);

        /// <summary>
        /// Causes the layer to clear all the tiles and request them again.
        /// </summary>
        public virtual ValueTask Redraw() => this._JSRuntime.InvokeVoidAsync($"{Utils._BaseGridLayerObject}.redraw", this.Id, this._Map.Id);

        /// <summary>
        /// Normalizes the tileSize option into a point. Used by the createTile() method.
        /// </summary>
        /// <returns></returns>
        public virtual ValueTask<PointF> GetTileSize() => this._JSRuntime.InvokeAsync<PointF>($"{Utils._BaseGridLayerObject}.getTileSize", this.Id, this._Map.Id);
    }
}
