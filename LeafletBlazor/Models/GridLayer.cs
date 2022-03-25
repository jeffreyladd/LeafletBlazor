using LeafletBlazor.EventHandlers;
using Microsoft.JSInterop;

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
    }
}
