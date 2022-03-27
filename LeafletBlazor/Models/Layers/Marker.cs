using LeafletBlazor.EventHandlers;
using Microsoft.JSInterop;

namespace LeafletBlazor.Models
{
    public sealed class Marker : InteractiveLayer
    {
        public delegate void MarkerEventHandler(object sender, Event e);

        /// <summary>
        /// Fired when the marker is moved via setLatLng or by dragging. Old and new coordinates are included in event arguments as oldLatLng, latlng.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MarkerEventHandler OnMove;

        [JSInvokable]
        public void NotifyMove(Event e) => OnMove?.Invoke(this, e);

        /// <summary>
        /// Fired when the user starts dragging the marker.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MarkerEventHandler OnDragStart;

        [JSInvokable]
        public void NotifyDragStart(Event e) => OnDragStart?.Invoke(this, e);

        /// <summary>
        /// Fired when the marker starts moving (because of dragging).
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MarkerEventHandler OnMoveStart;

        [JSInvokable]
        public void NotifyMoveStart(Event e) => OnMoveStart?.Invoke(this, e);

        /// <summary>
        /// Fired repeatedly while the user drags the marker.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MarkerEventHandler OnDrag;

        [JSInvokable]
        public void NotifyDrag(Event e) => OnDrag?.Invoke(this, e);

        /// <summary>
        /// Fired when the user stops dragging the marker.
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MarkerEventHandler OnDragEnd;

        [JSInvokable]
        public void NotifyDragEnd(MouseEvent e) => OnDragEnd?.Invoke(this, e);

        /// <summary>
        /// Fired when the marker stops moving (because of dragging).
        /// <para>Fired from leaflet.</para>
        /// </summary>
        public event MarkerEventHandler OnMoveEnd;

        [JSInvokable]
        public void NotifyMoveEnd(MouseEvent e) => OnMoveEnd?.Invoke(this, e);

        /// <summary>
        /// Returns the current geographical position of the marker.
        /// </summary>
        /// <returns></returns>
        public ValueTask<LatLng> GetLatLng() => this._JSRuntime.InvokeAsync<LatLng>($"{Utils._BaseMarkerObject}.getLatLng", this.Id, this._Map.Id);

        /// <summary>
        /// Changes the marker position to the given point.
        /// </summary>
        /// <param name="latLng"></param>
        /// <returns></returns>
        public ValueTask SetLatLng(LatLng latLng) => this._JSRuntime.InvokeVoidAsync($"{Utils._BaseMarkerObject}.setLatLng", this.Id, this._Map.Id, latLng);

        /// <summary>
        /// Changes the marker position to the given point.
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        public ValueTask SetZIndexOffset(int offset) => this._JSRuntime.InvokeVoidAsync($"{Utils._BaseMarkerObject}.setZIndexOffset", this.Id, this._Map.Id, offset);

        /// <summary>
        /// Returns the current icon used by the marker
        /// </summary>
        /// <returns></returns>
        public ValueTask<Icon> GetIcon() => this._JSRuntime.InvokeAsync<Icon>($"{Utils._BaseMarkerObject}.getIcon", this.Id, this._Map.Id);

        /// <summary>
        /// Changes the marker icon.
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        public ValueTask SetIcon(Icon icon) => this._JSRuntime.InvokeVoidAsync($"{Utils._BaseMarkerObject}.setIcon", this.Id, this._Map.Id, icon);

        /// <summary>
        /// Changes the opacity of the marker.
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        public ValueTask SetOpacity(double op) => this._JSRuntime.InvokeVoidAsync($"{Utils._BaseMarkerObject}.setOpacity", this.Id, this._Map.Id, op);
    }
}
