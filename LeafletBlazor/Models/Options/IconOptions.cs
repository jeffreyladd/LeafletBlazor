using System.Drawing;

namespace LeafletBlazor.Models
{
    public record IconOptions
    {
        /// <summary>
        /// (required) The URL to the icon image (absolute or relative to your script path).
        /// </summary>
        public string IconUrl { get; init; } = "";

        /// <summary>
        /// The URL to a retina sized version of the icon image (absolute or relative to your script path). Used for Retina screen devices.
        /// </summary>
        public string IconRetinaUrl { get; init; } = "";

        /// <summary>
        /// Size of the icon image in pixels.
        /// </summary>
        public PointF? IconSize { get; init; } = null;

        /// <summary>
        /// The coordinates of the "tip" of the icon (relative to its top left corner). The icon will be aligned so that this point is at the marker's geographical location. Centered by default if size is specified, also can be init in CSS with negative margins.
        /// </summary>
        public PointF? IconAnchor { get; init; } = null;

        /// <summary>
        /// The coordinates of the point from which popups will "open", relative to the icon anchor.
        /// </summary>
        public PointF? PopupAnchor { get; init; } = new PointF(0, 0);

        /// <summary>
        /// The coordinates of the point from which tooltips will "open", relative to the icon anchor.
        /// </summary>
        public PointF? TooltipAnchor { get; init; } = new PointF(0, 0);

        /// <summary>
        /// The URL to the icon shadow image. If not specified, no shadow image will be created.
        /// </summary>
        public string ShadowUrl { get; init; } = "";

        public string ShadowRetinaUrl { get; init; } = "";

        /// <summary>
        /// Size of the shadow image in pixels.
        /// </summary>
        public PointF? ShadowSize { get; init; } = null;

        /// <summary>
        /// The coordinates of the "tip" of the shadow (relative to its top left corner) (the same as iconAnchor if not specified).
        /// </summary>
        public PointF? ShadowAnchor { get; init; } = null;

        /// <summary>
        /// A custom class name to assign to both icon and shadow images. Empty by default.
        /// </summary>
        public string ClassName { get; init; } = "";
    }
}
