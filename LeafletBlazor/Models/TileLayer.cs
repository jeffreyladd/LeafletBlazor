using System.Drawing;

namespace LeafletBlazor.Models
{
    /// <summary>
    /// The Tile Layer that should be used.
    /// </summary>
    public class TileLayer : Layer
    {
        public TileLayer() : base() { }

        /// <summary>
        /// Instantiates a tile layer object given a URL template.
        /// </summary>
        public string UrlTemplate { get; set; }

        /// <summary>
        /// String to be shown in the attribution control, e.g. "© OpenStreetMap contributors". It describes the layer data and is often a legal obligation towards copyright holders and tile providers.
        /// </summary>
        public string Attribution { get; set; }

        /// <summary>
        /// The minimum zoom level down to which this layer will be displayed (inclusive).
        /// </summary>
        public float MinimumZoom { get; set; }

        /// <summary>
        /// The maximum zoom level up to which this layer will be displayed (inclusive).
        /// </summary>
        public float MaximumZoom { get; set; } = 18;

        /// <summary>
        /// Subdomains of the tile service.
        /// </summary>
        public string[] Subdomains { get; set; } = new string[] { "abc" };

        /// <summary>
        /// URL to the tile image to show in place of the tile that failed to load.
        /// </summary>
        public string ErrorTileUrl { get; set; }

        /// <summary>
        /// If set to true, the zoom number used in tile URLs will be reversed (maxZoom - zoom instead of zoom)
        /// </summary>
        public bool IsZoomReversed { get; set; }

        /// <summary>
        /// The zoom number used in tile URLs will be offset with this value.
        /// </summary>
        public double ZoomOffset { get; set; }

        /// <summary>
        /// If true and user is on a retina display, it will request four tiles of half the specified size and a bigger zoom level in place of one to utilize the high resolution.
        /// </summary>
        public bool DetectRetina { get; set; }

        /// <summary>
        /// Width and height of tiles in the grid.
        /// </summary>
        public Size TileSize { get; set; } = new Size(256, 256);

        public double Opacity { get; set; } = 1.0;

        /// <summary>
        /// By default, a smooth zoom animation will update grid layers every integer zoom level. Setting this option to false will update the grid layer only when the smooth animation ends.
        /// </summary>
        public bool UpdateWhenZooming { get; set; } = true;

        /// <summary>
        /// Tiles will not update more than once every updateInterval milliseconds when panning.
        /// </summary>
        public int UpdateInterval { get; set; } = 200;

        public int ZIndex { get; set; } = 1;

        /// <summary>
        /// If set, tiles will only be loaded inside the set.
        /// </summary>
        public Tuple<LatLng, LatLng> Bounds { get; set; }
    }
}
