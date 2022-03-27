namespace LeafletBlazor.Models
{
    public record VideoOverlayOptions : ImageOverlayOptions
    {
        /// <summary>
        /// Whether the video starts playing automatically when loaded.
        /// </summary>
        public bool Autoplay { get; init; } = true;

        /// <summary>
        /// Whether the video will loop back to the beginning when played.
        /// </summary>
        public bool Loop { get; init; } = true;

        /// <summary>
        /// Whether the video will save aspect ratio after the projection. Relevant for supported browsers. See browser compatibility
        /// </summary>
        public bool KeepAspectRatio { get; init; } = true;

        /// <summary>
        /// Whether the video starts on mute when loaded.
        /// </summary>
        public bool Muted { get; init; } = false;
    }
}
