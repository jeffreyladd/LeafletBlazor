namespace LeafletBlazor.Models
{
    public record WmsLayerOptions : TileLayerOptions
    {
        /// <summary>
        /// (required) Comma-separated list of WMS layers to show.
        /// </summary>
        public string Layers { get; init; } = "";

        /// <summary>
        /// Comma-separated list of WMS styles.
        /// </summary>
        public string Styles { get; init; } = "";

        /// <summary>
        /// WMS image format (use 'image/png' for layers with transparency).
        /// </summary>
        public string Format { get; set; } = "image/jpeg";

        /// <summary>
        /// If true, the WMS service will return images with transparency.
        /// </summary>
        public bool Transparent { get; set; } = false;

        /// <summary>
        /// Version of the WMS service to use
        /// </summary>
        public string Version { get; set; } = "1.1.1";

        //TODO: Do CRS

        /// <summary>
        /// If true, WMS request parameter keys will be uppercase.
        /// </summary>
        public bool Uppercase { get; set; } = false;
    }
}
