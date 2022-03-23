using LeafletBlazor.Models;
using System.Drawing;

namespace LeafletBlazor.EventHandlers
{
    public sealed record MouseEvent : Event
    {
        public LatLng LatLng { get; init; }

        public PointF LayerPoint { get; init; }

        public PointF ContainerPoint { get; init; }
    }
}
