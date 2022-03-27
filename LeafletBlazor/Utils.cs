namespace LeafletBlazor
{
    /// <summary>
    /// Contains Extension Methods to be used internally by the library.
    /// </summary>
    internal static class Utils
    {
        internal static readonly string _BaseMapObject = "window.leafletBlazor";

        internal static readonly string _BaseLayerObject = "window.leafletLayer";

        internal static readonly string _BaseGridLayerObject = "window.leafletGridLayer";

        internal static readonly string _BaseTileLayerObject = "window.leafletTileLayer";

        internal static readonly string _BaseWmsLayerObject = "window.leafletWmsLayer";

        internal static readonly string _BaseImageLayerObject = "window.leafletImageOverlayLayer";

        internal static readonly string _BaseVideoLayerObject = "window.leafletVideoOverlayLayer";

        internal static readonly string _BaseMarkerObject = "window.leafletMarkerLayer";

        static readonly Random _random = new Random();

        /// <summary>
        /// Method for generating a random string.
        /// </summary>
        /// <param name="length">The length of the random string.</param>
        /// <returns></returns>
        internal static string GetRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
