using System.Drawing;

namespace LeafletBlazor.Models
{
    public record MarkerOptions : InteractiveLayerOptions
    {
        public LatLng LatLng { get; init; }

        /// <summary>
        /// Icon instance to use for rendering the marker. See Icon documentation for details on how to customize the marker icon. If not specified, a common instance of L.Icon.Default is used.
        /// </summary>
        public Icon? Icon { get; init; } = null;

        /// <summary>
        /// Whether the marker can be tabbed to with a keyboard and clicked by pressing enter.
        /// </summary>
        public bool Keyboard { get; init; } = true;

        /// <summary>
        /// Text for the browser tooltip that appear on marker hover (no tooltip by default).
        /// </summary>
        public string Title { get; init; } = "";

        /// <summary>
        /// Text for the alt attribute of the icon image (useful for accessibility).
        /// </summary>
        public string Alt { get; init; } = "";

        /// <summary>
        /// By default, marker images zIndex is set automatically based on its latitude. Use this option if you want to put the marker on top of all others (or below), specifying a high value like 1000 (or high negative value, respectively).
        /// </summary>
        public int ZIndexOffset { get; init; } = 0;

        /// <summary>
        /// The opacity of the marker.
        /// </summary>
        public double Opacity { get; init; } = 1.0;

        /// <summary>
        /// If true, the marker will get on top of others when you hover the mouse over it.
        /// </summary>
        public bool RiseOnHover { get; init; } = false;

        /// <summary>
        /// The z-index offset used for the riseOnHover feature.
        /// </summary>
        public int RiseOffset { get; init; } = 250;

        /// <summary>
        /// Map pane where the markers icon will be added.
        /// </summary>
        public override string Pane { get; init; } = "markerPane";

        /// <summary>
        /// Map pane where the markers shadow will be added.
        /// </summary>
        public string ShadowPane { get; init; } = "";

        /// <summary>
        /// When true, a mouse event on this marker will trigger the same event on the map (unless L.DomEvent.stopPropagation is used).
        /// </summary>
        public override bool BubblingMouseEvents { get; init; } = false;

        /// <summary>
        /// Whether the marker is draggable with mouse/touch or not.
        /// </summary>
        public bool Draggable { get; init; } = false;

        /// <summary>
        /// Whether to pan the map when dragging this marker near its edge or not.
        /// </summary>
        public bool AutoPan { get; init; } = false;

        /// <summary>
        /// Distance (in pixels to the left/right and to the top/bottom) of the map edge to start panning the map.
        /// </summary>
        public PointF AutoPanPadding { get; init; } = new PointF(50, 50);

        /// <summary>
        /// Number of pixels the map should pan by.
        /// </summary>
        public int AutoPanSpeed { get; init; } = 10;

        /// <summary>
        /// If false, the layer will not emit mouse events and will act as a part of the underlying map.
        /// </summary>
        public override bool Interactive { get; init; } = true;
    }
}
