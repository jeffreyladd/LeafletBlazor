using System.Drawing;

namespace LeafletBlazor.Models
{
    public abstract record GridLayerOptions : LayerOptions
    {
        /// <summary>
        /// Width and height of tiles in the grid. Use a number if width and height are equal, or L.point(width, height) otherwise.
        /// </summary>
        public virtual Size TileSize { get; init; } = new Size(256, 256);

        /// <summary>
        /// Opacity of the tiles. Can be used in the createTile() function
        /// </summary>
        public virtual double Opacity { get; init; } = 1.0;

        /// <summary>
        /// Load new tiles only when panning ends. true by default on mobile browsers, in order to avoid too many requests and keep smooth navigation. false otherwise in order to display new tiles during panning, since it is easy to pan outside the keepBuffer option in desktop browsers.
        /// </summary>
        public virtual bool UpdateWhenIdle { get; init; } = true;

        /// <summary>
        /// By default, a smooth zoom animation (during a touch zoom or a flyTo()) will update grid layers every integer zoom level. Setting this option to false will update the grid layer only when the smooth animation ends.
        /// </summary>
        public virtual bool UpdateWhenZooming { get; init; } = true;

        /// <summary>
        /// Tiles will not update more than once every updateInterval milliseconds when panning.
        /// </summary>
        public virtual int UpdateInterval { get; init; } = 200;

        /// <summary>
        /// The explicit zIndex of the tile layer.
        /// </summary>
        public virtual int ZIndex { get; init; } = 1;

        /// <summary>
        /// If set, tiles will only be loaded inside the set LatLngBounds.
        /// </summary>
        public virtual LatLngBounds? Bounds { get; init; } = null;

        /// <summary>
        /// The minimum zoom level down to which this layer will be displayed (inclusive).
        /// </summary>
        public virtual double MinZoom { get; init; } = 0;

        /// <summary>
        /// The maximum zoom level up to which this layer will be displayed (inclusive).
        /// </summary>
        public virtual double? MaxZoom { get; init; }

        /// <summary>
        /// Maximum zoom number the tile source has available. If it is specified, the tiles on all zoom levels higher than maxNativeZoom will be loaded from maxNativeZoom level and auto-scaled.
        /// </summary>
        public virtual double? MaxNativeZoom { get; init; }

        /// <summary>
        /// Minimum zoom number the tile source has available. If it is specified, the tiles on all zoom levels lower than minNativeZoom will be loaded from minNativeZoom level and auto-scaled.
        /// </summary>
        public virtual double? MinNativeZoom { get; init; }

        /// <summary>
        /// Whether the layer is wrapped around the antimeridian. If true, the GridLayer will only be displayed once at low zoom levels. Has no effect when the map CRS doesn't wrap around. Can be used in combination with bounds to prevent requesting tiles outside the CRS limits.
        /// </summary>
        public virtual bool NoWrap { get; init; } = false;

        ///<inheritdoc/>
        public override string Pane { get; init; } = "tilePane";

        /// <summary>
        /// A custom class name to assign to the tile layer. Empty by default.
        /// </summary>
        public virtual string ClassName { get; init; } = "";

        /// <summary>
        /// When panning the map, keep this many rows and columns of tiles before unloading them.
        /// </summary>
        public virtual int KeepBuffer { get; set; } = 2;
    }
}
