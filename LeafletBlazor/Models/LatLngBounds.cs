using Microsoft.JSInterop;

namespace LeafletBlazor.Models
{
    public sealed class LatLngBounds
    {
        public LatLngBounds(LatLng corner1, LatLng corner2)
        {
            this.Bounds = new LatLng[] { corner1, corner2 };
        }

        public LatLngBounds(LatLng[] latlngs)
        {
            this.Bounds = latlngs;
        }

        public LatLng[] Bounds { get; }
    }
}
