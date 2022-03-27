namespace LeafletBlazor.Models
{
    public abstract record InteractiveLayerOptions : LayerOptions
    {
        /// <summary>
        /// If true, the image overlay will emit mouse events when clicked or hovered.
        /// </summary>
        public virtual bool Interactive { get; init; } = true;

        /// <summary>
        /// When true, a mouse event on this layer will trigger the same event on the map (unless L.DomEvent.stopPropagation is used).
        /// </summary>
        public virtual bool BubblingMouseEvents { get; init; } = true;
    }
}
