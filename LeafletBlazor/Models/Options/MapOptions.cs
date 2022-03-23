namespace LeafletBlazor.Models
{
    /// <summary>
    /// The options that are passed to the Map during initalization. 
    /// </summary>
    public record MapOptions
    {
        /// <summary>
        /// Determines whether paths should be rendered on a canvas renderer.
        /// <para>By default, all Paths are rendered in a SVG renderer.</para>
        /// </summary>
        public bool PreferCanvas { get; init; } = false;
        /// <summary>
        /// Determines whether an attribution control is added to the map by default.  
        /// <para>By default, this is true.</para>
        /// </summary>
        public bool AttributionControl { get; init; } = true;
        /// <summary>
        /// Determines whether a zoom control is added to the map by default. 
        /// <para>By default, this is true.</para>
        /// </summary>
        public bool ZoomControl { get; init; } = true;
        /// <summary>
        /// Determines if you want popups to close when the map is clicked.  
        /// <para>By Default, this is true.</para>
        /// </summary>
        public bool ClosePopupOnClick { get; init; } = true;
        /// <summary>
        /// Forces the map's zoom level to always be a multiple of this, particularly right after a fitBounds() or a pinch-zoom. By default, the zoom level snaps to the nearest integer; lower values (e.g. 0.5 or 0.1) allow for greater granularity. A value of 0 means the zoom level will not be snapped after fitBounds or a pinch-zoom.
        /// </summary>
        public double ZoomSnap { get; init; } = 1;
        /// <summary>
        /// Controls how much the map's zoom level will change after a zoomIn(), zoomOut(), pressing + or - on the keyboard, or using the zoom controls. Values smaller than 1 (e.g. 0.5) allow for greater granularity.
        /// </summary>
        public double ZoomDelta { get; init; } = 1;
        /// <summary>
        /// Determines whether the map automatically handles browser window resize to update itself.
        /// </summary>
        public bool TrackResize { get; init; } = true;
        /// <summary>
        /// Whether the map can be zoomed to a rectangular area specified by dragging the mouse while pressing the shift key.
        /// </summary>
        public bool BoxZoom { get; init; } = true;
        /// <summary>
        /// Whether the map can be zoomed in by double clicking on it and zoomed out by double clicking while holding shift. If passed 'center', double-click zoom will zoom to the center of the view regardless of where the mouse was.
        /// </summary>
        public bool DoubleClickZoom { get; init; } = true;
        /// <summary>
        /// Whether the map be draggable with mouse/touch or not.
        /// </summary>
        public bool Dragging { get; init; } = true;
        //// TODO: Need to do CRS
        /// <summary>
        /// Whether the map be draggable with mouse/touch or not.
        /// </summary>
        public LatLng Center { get; init; } = new LatLng(0,0);
        /// <summary>
        /// Initial map zoom level
        /// </summary>
        public double? Zoom { get; init; }
        /// <summary>
        /// Minimum zoom level of the map. If not specified and at least one GridLayer or TileLayer is in the map, the lowest of their MinZoom options will be used instead.
        /// </summary>
        public double? MinZoom { get; init; }
        /// <summary>
        /// Maximum zoom level of the map. If not specified and at least one GridLayer or TileLayer is in the map, the highest of their MaxZoom options will be used instead.
        /// </summary>
        public double? MaxZoom { get; init; }
        /// <summary>
        /// Array of layers that will be added to the map initially
        /// </summary>
        //public IEnumerable<Layer> Layers { get; init; } = new List<Layer>();

        // TODO: DO MaxBounds and renderer.
        /// <summary>
        /// Whether the map zoom animation is enabled. By default it's enabled in all browsers that support CSS3 Transitions except Android.
        /// </summary>
        public bool ZoomAnimation { get; init; } = true;
        /// <summary>
        /// Won't animate zoom if the zoom difference exceeds this value.
        /// </summary>
        public int ZoomAnimationThreshold { get; init; } = 4;
        /// <summary>
        /// Whether the tile fade animation is enabled. By default it's enabled in all browsers that support CSS3 Transitions except Android.
        /// </summary>
        public bool FadeAnimation { get; init; } = true;
        /// <summary>
        /// Whether markers animate their zoom with the zoom animation, if disabled they will disappear for the length of the animation. By default it's enabled in all browsers that support CSS3 Transitions except Android.
        /// </summary>
        public bool MarkerZoomAnimation { get; init; } = true;
        //TODO: Do transform3DLimit
        /// <summary>
        /// f enabled, panning of the map will have an inertia effect where the map builds momentum while dragging and continues moving in the same direction for some time. Feels especially nice on touch devices. Enabled by default unless running on old Android devices.
        /// </summary>
        public bool Inertia { get; init; } = true;
        /// <summary>
        /// The rate with which the inertial movement slows down, in pixels/second².
        /// </summary>
        public int InertiaDeceleration { get; init; } = 3000;
        /// <summary>
        /// Max speed of the inertial movement, in pixels/second.
        /// </summary>
        public int InertiaMaxSpeed { get; init; } = int.MaxValue;
        public double EaseLinearity { get; init; } = 0.2;
        /// <summary>
        /// With this option enabled, the map tracks when you pan to another "copy" of the world and seamlessly jumps to the original one so that all overlays like markers and vector layers are still visible.
        /// </summary>
        public bool WorldCopyJump { get; init; } = false;
        /// <summary>
        /// If maxBounds is set, this option will control how solid the bounds are when dragging the map around. The default value of 0.0 allows the user to drag outside the bounds at normal speed, higher values will slow down map dragging outside bounds, and 1.0 makes the bounds fully solid, preventing the user from dragging outside the bounds.
        /// </summary>
        public double MaxBoundsViscosity { get; init; } = 0.0;
        /// <summary>
        /// Makes the map focusable and allows users to navigate the map with keyboard arrows and +/- keys.
        /// </summary>
        public bool Keyboard { get; init; } = true;
        /// <summary>
        /// Amount of pixels to pan when pressing an arrow key.
        /// </summary>
        public int KeyboardPanDelta { get; init; } = 80;
        /// <summary>
        /// Whether the map can be zoomed by using the mouse wheel. If passed 'center', it will zoom to the center of the view regardless of where the mouse was.
        /// </summary>
        public bool ScrollWheelZoom { get; init; } = true;
        /// <summary>
        /// Limits the rate at which a wheel can fire (in milliseconds). By default user can't zoom via wheel more often than once per 40 ms.
        /// </summary>
        public int WheelDebounceTime { get; init; } = 40;
        /// <summary>
        /// How many scroll pixels (as reported by L.DomEvent.getWheelDelta) mean a change of one full zoom level. Smaller values will make wheel-zooming faster (and vice versa).
        /// </summary>
        public int WheelPxPerZoomLevel { get; init; } = 60;
        /// <summary>
        /// Enables mobile hacks for supporting instant taps (fixing 200ms click delay on iOS/Android) and touch holds (fired as contextmenu events).
        /// </summary>
        public bool Tap { get; init; } = true;
        /// <summary>
        /// The max number of pixels a user can shift his finger during touch for it to be considered a valid tap.
        /// </summary>
        public int TapTolerance { get; init; } = 15;
        /// <summary>
        /// Whether the map can be zoomed by touch-dragging with two fingers. If passed 'center', it will zoom to the center of the view regardless of where the touch events (fingers) were. Enabled for touch-capable web browsers except for old Androids.
        /// </summary>
        public bool TouchZoom { get; init; } = true;
        /// <summary>
        /// Set it to false if you don't want the map to zoom beyond min/max zoom and then bounce back when pinch-zooming.
        /// </summary>
        public bool BounceAtZoomLimits { get; init; } = true;
    }
}
