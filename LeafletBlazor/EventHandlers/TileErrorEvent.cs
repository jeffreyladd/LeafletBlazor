namespace LeafletBlazor.EventHandlers
{
    public record TileErrorEvent : TileEvent
    {
        public object Error { get; init; }
    }
}
