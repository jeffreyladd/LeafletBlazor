namespace LeafletBlazor.Models
{
    /// <summary>
    /// Represents a geographical point with a certain latitude and longitude.
    /// </summary>
    public record LatLng
    {
        public LatLng() { }

        public LatLng(double lat, double lng, double? alt = null)
        {
            this.Lat = lat;
            this.Lng = lng;
            this.Alt = alt;
        }

        /// <summary>
        /// The Latitude in degrees.
        /// </summary>
        public double Lat { get; init; }

        /// <summary>
        /// The Longitude in degrees.
        /// </summary>
        public double Lng { get; init; }

        /// <summary>
        /// The Altitude in meters (optional).
        /// </summary>
        public double? Alt { get; init; }
    }
}
