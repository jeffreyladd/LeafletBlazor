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
