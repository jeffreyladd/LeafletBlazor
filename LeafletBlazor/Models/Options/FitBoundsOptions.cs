using System.Drawing;

namespace LeafletBlazor.Models
{
    public record FitBoundsOptions
    {
        /// <summary>
        /// Sets the amount of padding in the top left corner of a map container that shouldn't be accounted for when setting the view to fit bounds. Useful if you have some control overlays on the map like a sidebar and you don't want them to obscure objects you're zooming to.
        /// </summary>
        public PointF PaddingTopLeft { get; init; } = new PointF(0, 0);
        /// <summary>
        /// The same for the bottom right corner of the map.
        /// </summary>
        public PointF PaddingBottomRight { get; init; } = new PointF(0, 0);
        /// <summary>
        /// Equivalent of setting both top left and bottom right padding to the same value.
        /// </summary>
        public PointF Padding { get; init; } = new PointF(0, 0);
        /// <summary>
        /// The maximum possible zoom to use.
        /// </summary>
        public int? MaxZoom { get; init; } = null;
    }
}
