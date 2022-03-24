using LeafletBlazor.EventHandlers;
using LeafletBlazor.Models;
using Microsoft.JSInterop;
using System.Collections.Specialized;

namespace LeafletBlazor
{
    public partial class LeafletBlazorMap
    {
        //TODO: Do Layer events on Map

        /// <summary>
        /// Event raised when the component has finished its first render.
        /// </summary>
        public event Action OnInit;
        public delegate void MapEventHandler(object sender, Event e);

        /// <summary>
        /// Fired when the number of zoomlevels on the map is changed due to adding or removing a layer.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MapEventHandler OnZoomLevelsChange;
        [JSInvokable]
        public void NotifyZoomLevelsChange(Event e) => OnZoomLevelsChange?.Invoke(this, e);

        /// <summary>
        /// Fired when the map is resized.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MapEventHandler OnResize;
        [JSInvokable]
        public void NotifyResize(ResizeEvent e) => OnResize?.Invoke(this, e);

        /// <summary>
        /// Fired when the map is destroyed with remove method.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MapEventHandler OnUnload;
        [JSInvokable]
        public void NotifyUnload(Event e) => OnUnload?.Invoke(this, e);

        /// <summary>
        /// Fired when the map needs to redraw its content (this usually happens on map zoom or load). Very useful for creating custom overlays.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MapEventHandler OnViewReset;
        [JSInvokable]
        public void NotifyViewReset(Event e) => OnViewReset?.Invoke(this, e);

        /// <summary>
        /// Fired when the map is initialized (when its center and zoom are set for the first time).
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MapEventHandler OnLoad;
        [JSInvokable]
        public void NotifyLoad(Event e) => OnLoad?.Invoke(this, e);

        /// <summary>
        /// Fired when the map zoom is about to change (e.g. before zoom animation).
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MapEventHandler OnZoomStart;
        [JSInvokable]
        public void NotifyZoomStart(Event e) => OnZoomStart?.Invoke(this, e);

        /// <summary>
        /// Fired when the view of the map starts changing (e.g. user starts dragging the map).
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MapEventHandler OnMoveStart;
        [JSInvokable]
        public void NotifyMoveStart(Event e) => OnMoveStart?.Invoke(this, e);

        /// <summary>
        /// Fired repeatedly during any change in zoom level, including zoom and fly animations.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MapEventHandler OnZoom;
        [JSInvokable]
        public void NotifyZoom(Event e) => OnZoom?.Invoke(this, e);

        /// <summary>
        /// Fired repeatedly during any movement of the map, including pan and fly animations.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MapEventHandler OnMove;
        [JSInvokable]
        public void NotifyMove(Event e) => OnMove?.Invoke(this, e);

        /// <summary>
        /// Fired when the map zoom has changed, after any animations.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MapEventHandler OnZoomEnd;
        [JSInvokable]
        public void NotifyZoomEnd(Event e) => OnZoomEnd?.Invoke(this, e);

        /// <summary>
        /// Fired when the center of the map stops changing (e.g. user stopped dragging the map or when a non-centered zoom ends).
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MapEventHandler OnMoveEnd;
        [JSInvokable]
        public void NotifyMoveEnd(Event e) => OnMoveEnd?.Invoke(this, e);

        //TODO: do Popup,Tooltip, and Location events

        /// <summary>
        /// Fired when the user clicks (or taps) the map.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MapEventHandler OnClick;
        [JSInvokable]
        public void NotifyClick(MouseEvent e) => OnClick?.Invoke(this, e);

        /// <summary>
        /// Fired when the user double-clicks (or double-taps) the map.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MapEventHandler OnDblClick;
        [JSInvokable]
        public void NotifyDblClick(MouseEvent e) => OnDblClick?.Invoke(this, e);

        /// <summary>
        /// Fired when the user pushes the mouse button on the map.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MapEventHandler OnMouseDown;
        [JSInvokable]
        public void NotifyMouseDown(MouseEvent e) => OnMouseDown?.Invoke(this, e);

        /// <summary>
        /// Fired when the user releases the mouse button on the map.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MapEventHandler OnMouseUp;
        [JSInvokable]
        public void NotifyMouseUp(MouseEvent e) => OnMouseUp?.Invoke(this, e);

        /// <summary>
        /// Fired when the mouse enters the map.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MapEventHandler OnMouseOver;
        [JSInvokable]
        public void NotifyMouseOver(MouseEvent e) => OnMouseOver?.Invoke(this, e);

        /// <summary>
        /// Fired when the mouse leaves the map.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MapEventHandler OnMouseOut;
        [JSInvokable]
        public void NotifyMouseOut(MouseEvent e) => OnMouseOut?.Invoke(this, e);

        /// <summary>
        /// Fired while the mouse moves over the map.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MapEventHandler OnMouseMove;
        [JSInvokable]
        public void NotifyMouseMove(MouseEvent e) => OnMouseMove?.Invoke(this, e);

        /// <summary>
        /// Fired when the user pushes the right mouse button on the map, prevents default browser context menu from showing if there are listeners on this event. Also fired on mobile when the user holds a single touch for a second (also called long press).
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MapEventHandler OnContextMenu;
        [JSInvokable]
        public void NotifyContextMenu(MouseEvent e) => OnContextMenu?.Invoke(this, e);

        /// <summary>
        /// Fired when the user presses a key from the keyboard that produces a character value while the map is focused.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MapEventHandler OnKeyPress;
        [JSInvokable]
        public void NotifyKeyPress(Event e) => OnKeyPress?.Invoke(this, e);

        /// <summary>
        /// Fired when the user presses a key from the keyboard while the map is focused. Unlike the keypress event, the keydown event is fired for keys that produce a character value and for keys that do not produce a character value.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MapEventHandler OnKeyDown;
        [JSInvokable]
        public void NotifyKeyDown(Event e) => OnKeyDown?.Invoke(this, e);

        /// <summary>
        /// Fired when the user releases a key from the keyboard while the map is focused.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MapEventHandler OnKeyUp;
        [JSInvokable]
        public void NotifyKeyUp(Event e) => OnKeyUp?.Invoke(this, e);

        /// <summary>
        /// Fired before mouse click on the map (sometimes useful when you want something to happen on click before any existing click handlers start running).
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MapEventHandler OnPreClick;
        [JSInvokable]
        public void NotifyPreClick(MouseEvent e) => OnPreClick?.Invoke(this, e);

        //TODO: zoomanim event

        void OnLayersChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (args.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in args.NewItems)
                {
                    var layer = item as Layer;
                    LeafletInterops.Map.AddLayer(this.JsRuntime, this.Id, layer);
                }
            }
            else if (args.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in args.OldItems)
                {
                    if (item is Layer layer)
                    {
                        LeafletInterops.Map.RemoveLayer(this.JsRuntime, this.Id, layer.Id);
                    }
                }
            }
            else if (args.Action == NotifyCollectionChangedAction.Replace
                     || args.Action == NotifyCollectionChangedAction.Move)
            {
                foreach (var oldItem in args.OldItems)
                    if (oldItem is Layer layer)
                        LeafletInterops.Map.RemoveLayer(this.JsRuntime, this.Id, layer.Id);

                foreach (var newItem in args.NewItems)
                    LeafletInterops.Map.AddLayer(this.JsRuntime, this.Id, newItem as Layer);
            }
        }
    }
}
