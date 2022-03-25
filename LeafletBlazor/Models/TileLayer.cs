namespace LeafletBlazor.Models
{
    /// <summary>
    /// The Tile Layer that should be used.
    /// </summary>
    public class TileLayer : GridLayer
    {
        public TileLayer(TileLayerOptions options) : base() { this.Options = options; }

        public TileLayerOptions Options { get; private set; }

        public override void AddTo(LeafletBlazorMap map)
        {
            throw new NotImplementedException();
        }

        public override void GetAttribution()
        {
            throw new NotImplementedException();
        }

        public override void Remove()
        {
            throw new NotImplementedException();
        }

        public override void RemoveFrom(LeafletBlazorMap map)
        {
            throw new NotImplementedException();
        }
    }
}
