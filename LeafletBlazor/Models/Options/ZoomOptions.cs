namespace LeafletBlazor.Models
{
    public sealed record ZoomOptions
    {
        /// <summary>
        /// If not specified, zoom animation will happen if the zoom origin is inside the current view. If true, the map will attempt animating zoom disregarding where zoom origin is. Setting false will make it always reset the view completely without animation.
        /// </summary>
        public bool? Animate { get; init; }
    }
}
