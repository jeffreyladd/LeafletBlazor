namespace LeafletBlazor.Models
{
    /// <summary>
    /// The base of all layers that can added.
    /// </summary>
    public abstract class Layer
    {
        protected Layer()
        {
            Id = Utils.GetRandomString(20);
        }

        /// <summary>
        /// Unique identifier used by the interoperability service on the client side to identify layers.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// By default the layer will be added to the map's overlay pane. Overriding this option will cause the layer to be placed on another pane by default.
        /// </summary>
        public virtual string Pane { get; set; } = "overlayPane";
    }
}
