using System.Drawing;

namespace LeafletBlazor.EventHandlers
{
    public record TileEvent : Event
    {
        /// <summary>
        /// The tile element (image).
        /// </summary>
        public object Tile { get; init; }

        /// <summary>
        /// Point object with the tile's x, y, and z (zoom level) coordinates.
        /// </summary>
        public PointF Coords { get; init; }
    }
}
