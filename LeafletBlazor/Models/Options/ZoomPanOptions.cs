namespace LeafletBlazor.Models
{
    public sealed record ZoomPanOptions
    {
        /// <summary>
        /// If not specified, zoom animation will happen if the zoom origin is inside the current view. If true, the map will attempt animating zoom disregarding where zoom origin is. Setting false will make it always reset the view completely without animation.
        /// </summary>
        public bool? Animate { get; init; }
        /// <summary>
        /// Duration of animated panning, in seconds.
        /// </summary>
        public double Duration { get; init; } = 0.25;
        /// <summary>
        /// The curvature factor of panning animation easing (third parameter of the Cubic Bezier curve). 1.0 means linear animation, and the smaller this number, the more bowed the curve.
        /// </summary>
        public double EaseLinearity { get; init; } = 0.25;
        /// <summary>
        /// If true, panning won't fire movestart event on start (used internally for panning inertia).
        /// </summary>
        public bool NoMoveStart { get; init; } = false;
    }
}
