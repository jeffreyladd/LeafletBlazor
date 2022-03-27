using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafletBlazor.Models
{
    public record ImageOverlayOptions : InteractiveLayerOptions
    {
        public string Url { get; init; } = "";

        public LatLngBounds Bounds { get; init; }

        /// <summary>
        /// The opacity of the image overlay.
        /// </summary>
        public double Opacity { get; init; } = 1.0;

        /// <summary>
        /// Text for the alt attribute of the image (useful for accessibility).
        /// </summary>
        public string Alt { get; init; } = "";

        /// <summary>
        /// If true, the image overlay will emit mouse events when clicked or hovered.
        /// </summary>
        public override bool Interactive { get; init; } = false;

        /// <summary>
        /// Whether the crossOrigin attribute will be added to the image. If a String is provided, the image will have its crossOrigin attribute set to the String provided. This is needed if you want to access image pixel data. Refer to CORS Settings for valid String values.
        /// </summary>
        public bool CrossOrigin { get; init; } = false;

        /// <summary>
        /// URL to the overlay image to show in place of the overlay that failed to load.
        /// </summary>
        public string ErrorOverlayUrl { get; init; } = "";

        /// <summary>
        /// The explicit zIndex of the overlay layer.
        /// </summary>
        public int ZIndex { get; init; } = 1;

        /// <summary>
        /// A custom class name to assign to the image. Empty by default.
        /// </summary>
        public string ClassName { get; init; } = "";
    }
}
