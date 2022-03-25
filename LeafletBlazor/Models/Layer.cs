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
            this.OnRemove?.Invoke(this, eventArgs);
        }


        //TODO: Add Popup and Toolip Events when they are added.


        public abstract void AddTo(LeafletBlazorMap map);

        public abstract void Remove();

        public abstract void RemoveFrom(LeafletBlazorMap map);

        //TODO: add GetPane

        public abstract void GetAttribution();

        //TODO: Add Popup and Toolip Methods when they are added.
    }
}
