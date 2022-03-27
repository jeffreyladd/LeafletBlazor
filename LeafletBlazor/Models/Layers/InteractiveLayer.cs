using LeafletBlazor.EventHandlers;
using Microsoft.JSInterop;

namespace LeafletBlazor.Models
{
    public abstract class InteractiveLayer : Layer
    {
        public delegate void InteractiveLayerEventHandler(object sender, MouseEvent e);


        /// <summary>
        /// Fired when the user clicks (or taps) the layer.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event InteractiveLayerEventHandler OnClick;

        [JSInvokable]
        public void NotifyClick(MouseEvent e) => OnClick?.Invoke(this, e);

        /// <summary>
        /// Fired when the user double-clicks (or double-taps) the layer.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event InteractiveLayerEventHandler OnDblClick;

        [JSInvokable]
        public void NotifyDblClick(MouseEvent e) => OnDblClick?.Invoke(this, e);

        /// <summary>
        /// Fired when the user pushes the mouse button on the layer.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event InteractiveLayerEventHandler OnMouseDown;

        [JSInvokable]
        public void NotifyMouseDown(MouseEvent e) => OnMouseDown?.Invoke(this, e);

        /// <summary>
        /// Fired when the user releases the mouse button on the layer.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event InteractiveLayerEventHandler OnMouseUp;

        [JSInvokable]
        public void NotifyMouseUp(MouseEvent e) => OnMouseUp?.Invoke(this, e);

        /// <summary>
        /// Fired when the mouse enters the layer.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event InteractiveLayerEventHandler OnMouseOver;

        [JSInvokable]
        public void NotifyMouseOver(MouseEvent e) => OnMouseOver?.Invoke(this, e);

        /// <summary>
        /// Fired when the mouse leaves the layer.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event InteractiveLayerEventHandler OnMouseOut;

        [JSInvokable]
        public void NotifyMouseOut(MouseEvent e) => OnMouseOut?.Invoke(this, e);

        /// <summary>
        /// Fired while the mouse moves over the layer.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event InteractiveLayerEventHandler OnMouseMove;

        [JSInvokable]
        public void NotifyMouseMove(MouseEvent e) => OnMouseMove?.Invoke(this, e);

        /// <summary>
        /// Fired when the user pushes the right mouse button on the layer, prevents default browser context menu from showing if there are listeners on this event. Also fired on mobile when the user holds a single touch for a second (also called long press).
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event InteractiveLayerEventHandler OnContextMenu;

        [JSInvokable]
        public void NotifyContextMenu(MouseEvent e) => OnContextMenu?.Invoke(this, e);
    }
}
