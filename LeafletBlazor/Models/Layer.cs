using LeafletBlazor.EventHandlers;
using Microsoft.JSInterop;

namespace LeafletBlazor.Models
{
    /// <summary>
    /// The base of all layers that can added.
    /// </summary>
    public abstract class Layer
    {
        protected Layer()
        {
            this.Id = Utils.GetRandomString(20);
        }

        /// <summary>
        /// Unique identifier used by the interoperability service on the client side to identify layers.
        /// </summary>
        public string Id { get; }

        internal LeafletBlazorMap _Map { get; set; }

        internal IJSRuntime _JSRuntime { get; set; }

        //TODO: do Tooltip and Popup when those controls are added

        public delegate void EventHandler(Layer sender, Event e);

        public event EventHandler OnAdd;

        [JSInvokable]
        public void NotifyAdd(Event eventArgs)
        {
            this.OnAdd?.Invoke(this, eventArgs);
        }

        public event EventHandler OnRemove;

        [JSInvokable]
        public void NotifyRemove(Event eventArgs)
        {
            this._Map._Layers.Remove(this);
            this.OnRemove?.Invoke(this, eventArgs);
        }


        //TODO: Add Popup and Toolip Events when they are added.

        /// <summary>
        /// Adds the layer to the given map or layer group.
        /// </summary>
        /// <param name="map">The map to add the layer to.</param>
        public virtual void AddTo(LeafletBlazorMap map) => map.AddLayer(this);

        /// <summary>
        /// Removes the layer from the map it is currently active on.
        /// </summary>
        /// <returns></returns>
        public virtual ValueTask Remove() => this._JSRuntime.InvokeVoidAsync($"{Utils._BaseLayerObject}.remove", this.Id, this._Map.Id);

        /// <summary>
        /// Removes the layer from the given map
        /// </summary>
        /// <param name="map">The map to remove the layer from.</param>
        public virtual void RemoveFrom(LeafletBlazorMap map) => map.RemoveLayer(this);

        //TODO: add GetPane

        /// <summary>
        /// Used by the attribution control, returns the attribution option.
        /// </summary>
        /// <returns></returns>
        public virtual ValueTask<string> GetAttribution() => this._JSRuntime.InvokeAsync<string>($"{Utils._BaseLayerObject}.getAttribution", this.Id, this._Map.Id);

        //TODO: Add Popup and Toolip Methods when they are added.
    }
}
