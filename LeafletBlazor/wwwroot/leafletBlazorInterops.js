maps = {};
layers = {};

window.leafletBlazor = {
    create: function (map, objectReference) {
        var leafletMap = new L.map(map.id, {
            preferCanvas: map.options.preferCanvas,
            attributionControl: map.options.attributionControl,
            zoomControl: map.options.zoomControl,
            closePopupOnClick: map.options.closePopupOnClick,
            zoomSnap: map.options.zoomSnap,
            zoomDelta: map.options.zoomDelta,
            trackResize: map.options.trackResize,
            boxZoom: map.options.boxZoom,
            doubleClickZoom: map.options.doubleClickZoom,
            dragging: map.options.dragging,
            center: L.latLng(map.options.center.lat, map.options.center.lng),
            zoom: map.options.zoom ? map.options.zoom : undefined,
            minZoom: map.options.minZoom ? map.options.minZoom : undefined,
            maxZoom: map.options.maxZoom ? map.options.maxZoom : undefined,
            //maxBounds: map.options.maxBounds && map.options.maxBounds.item1 && map.options.maxBounds.item2 ? L.latLngBounds(map.options.maxBounds.item1, map.options.maxBounds.item2) : undefined,
            zoomAnimation: map.options.zoomAnimation,
            zoomAnimationThreshold: map.options.zoomAnimationThreshold,
            fadeAnimation: map.options.fadeAnimation,
            markerZoomAnimation: map.options.markerZoomAnimation,
            //transform3DLimit
            inertia: map.options.inertia,
            inertiaDeceleration: map.options.inertiaDeceleration,
            inertiaMaxSpeed: map.options.inertiaMaxSpeed,
            easeLinearity: map.options.easeLinearity,
            worldCopyJump: map.options.worldCopyJump,
            maxBoundsViscosity: map.options.maxBoundsViscosity,
            keyboard: map.options.keyboard,
            keyboardPanDelta: map.options.keyboardPanDelta,
            scrollWheelZoom: map.options.scrollWheelZoom,
            wheelDebounceTime: map.options.wheelDebounceTime,
            wheelPxPerZoomLevel: map.options.wheelPxPerZoomLevel,
            tap: map.options.tap,
            tapTolerance: map.options.tapTolerance,
            touchZoom: map.options.touchZoom,
            bounceAtZoomLimits: map.options.bounceAtZoomLimits
        });
        connectMapEvents(leafletMap, objectReference);
        maps[map.id] = leafletMap;
        layers[map.id] = [];
    },
    addTilelayer: function (mapId, tileLayer, objectReference) {
        const layer = L.tileLayer(tileLayer.options.urlTemplate, {
            attribution: tileLayer.options.attribution,
            pane: tileLayer.options.pane,
            tileSize: tileLayer.options.tileSize ? L.point(tileLayer.options.tileSize.width, tileLayer.options.tileSize.height) : undefined,
            opacity: tileLayer.options.opacity,
            updateWhenZooming: tileLayer.options.updateWhenZooming,
            updateInterval: tileLayer.options.updateInterval,
            zIndex: tileLayer.options.zIndex,
            bounds: tileLayer.options.bounds && tileLayer.options.bounds.item1 && tileLayer.options.bounds.item2 ? L.latLngBounds(tileLayer.options.bounds.item1, tileLayer.options.bounds.item2) : undefined,
            minZoom: tileLayer.options.minimumZoom,
            maxZoom: tileLayer.options.maximumZoom,
            subdomains: tileLayer.options.subdomains,
            errorTileUrl: tileLayer.options.errorTileUrl,
            zoomOffset: tileLayer.options.zoomOffset,
            zoomReverse: tileLayer.options.isZoomReversed,
            detectRetina: tileLayer.options.detectRetina,
        });
        connectTileLayerEvents(layer, objectReference);
        addLayer(mapId, layer, tileLayer.id);
    },
    setMapView: function (mapId, center, zoom, options) {
        maps[mapId].setView(center, zoom, options);
    },
    setMapZoom: function (mapId, zoom, options) {
        maps[mapId].setZoom(zoom, options);
    },
    setZoomIn: function (mapId, delta, options) {
        maps[mapId].zoomIn(delta, options);
    },
    setZoomOut: function (mapId, delta, options) {
        maps[mapId].zoomOut(delta, options);
    },
    setZoomAround: function (mapId, center, zoom, options) {
        maps[mapId].setZoomAround(center, zoom, options)
    },
    setMinZoom: function (mapId, zoom) {
        maps[mapId].setMinZoom(zoom)
    },
    setMaxZoom: function (mapId, zoom) {
        maps[mapId].setMaxZoom(zoom)
    },
    panInside: function (mapId, latLng) {
        maps[mapId].panInside(latLng);
    },
    invalidateSize: function (mapId, options) {
        maps[mapId].invalidateSize(options);
    },
    stop: function (mapId) {
        maps[mapId].stop();
    },
    remove: function (mapId) {
        maps[mapId].remove();
    },
    getCenter: function (mapId) {
        return maps[mapId].getCenter();
    },
    getZoom: function (mapId) {
        return maps[mapId].getZoom();
    },
    getMinZoom: function (mapId) {
        return maps[mapId].getMinZoom();
    },
    getMaxZoom: function (mapId) {
        return maps[mapId].getMaxZoom();
    },
};

window.LeafletTileLayer = {
    bringToBack: function (mapId, layerId) {
        
    }
}

function cleanupEventArgsForSerialization(eventArgs) {

    const propertiesToRemove = [
        "target",
        "sourceTarget",
        "propagatedFrom",
        "originalEvent",
        "tooltip",
        "popup"
    ];

    const copy = {};

    for (let key in eventArgs) {
        if (!propertiesToRemove.includes(key) && eventArgs.hasOwnProperty(key)) {
            copy[key] = eventArgs[key];
        }
    }

    return copy;
}

function mapEvents(mapElement, objectReference, eventHandlerDict) {
    for (let key in eventHandlerDict) {

        const handlerName = eventHandlerDict[key];

        mapElement.on(key, function (eventArgs) {
            objectReference.invokeMethodAsync(handlerName,
                cleanupEventArgsForSerialization(eventArgs));
        });
    }
}

function connectMapEvents(map, objectReference) {

    mapEvents(map, objectReference, {
        "zoomlevelschange": "NotifyZoomLevelsChange",
        "resize": "NotifyResize",
        "unload": "NotifyUnload",
        "viewreset": "NotifyViewReset",
        "load": "NotifyLoad",
        "zoomstart": "NotifyZoomStart",
        "movestart": "NotifyMoveStart",
        "zoom": "NotifyZoom",
        "move": "NotifyMove",
        "zoomend": "NotifyZoomEnd",
        "moveend": "NotifyMoveEnd",
        "click": "NotifyClick",
        "dblclick": "NotifyDblClick",
        "mousedown": "NotifyMouseDown",
        "mouseup": "NotifyMouseUp",
        "mouseover": "NotifyMouseOver",
        "mouseout": "NotifyMouseOut",
        "mousemove": "NotifyMouseMove",
        "contextmenu": "NotifyContextMenu",        
        "keypress": "NotifyKeyPress",
        "keydown": "NotifyKeyDown",
        "keyup": "NotifyKeyUp",
        "preclick": "NotifyPreClick",
        
    });
}

function connectTileLayerEvents(layer, objectReference) {
    mapEvents(layer, objectReference, {
        "add": "NotifyAdd",
        "remove": "NotifyRemove",
        "popupopen": "NotifyPopupOpen",
        "popupclose": "NotifyPopupClose",
        "tooltipopen": "NotifyTooltipOpen",
        "tooltipclose": "NotifyTooltipClose",
        "loading": "NotifyLoading",
        "tileunload": "NotifyTileUnload",
        "tileloadstart": "NotifyTileLoadStart",
        "tileerror": "NotifyTileError",
        "tileload": "NotifyTileLoad",
        "load" : "NotifyLoad"
    });
}

function connectLayerEvents(layer, objectReference) {
    mapEvents(layer, objectReference, {
        "add": "NotifyAdd",
        "remove": "NotifyRemove",
        "popupopen": "NotifyPopupOpen",
        "popupclose": "NotifyPopupClose",
        "tooltipopen": "NotifyTooltipOpen",
        "tooltipclose": "NotifyTooltipClose",
    });
}

function connectInteractiveLayerEvents(interactiveLayer, objectReference) {

    connectLayerEvents(interactiveLayer, objectReference);
    connectInteractionEvents(interactiveLayer, objectReference);
}

function connectMarkerEvents(marker, objectReference) {

    connectInteractiveLayerEvents(marker, objectReference);

    mapEvents(marker, objectReference, {
        "move": "NotifyMove",
        "dragstart": "NotifyDragStart",
        "movestart": "NotifyMoveStart",
        "drag": "NotifyDrag",
        "dragend": "NotifyDragEnd",
        "moveend": "NotifyMoveEnd",
    });
}

function addLayer(mapId, layer, layerId) {
    layer.id = layerId;
    layers[mapId].push(layer);
    layer.addTo(maps[mapId]);
}