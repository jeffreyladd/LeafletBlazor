using System.Drawing;

namespace LeafletBlazor.EventHandlers
{
    public sealed record ResizeEvent : Event
    {
        public PointF OldSize { get; init; }
        public PointF NewSize { get; init; }
    }
}
