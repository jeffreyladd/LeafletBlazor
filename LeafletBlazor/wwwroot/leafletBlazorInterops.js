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
            maxBounds: map.options.maxBounds ? L.latLngBounds(map.options.maxBounds.bounds) : undefined,
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
    removeLayer: function (mapId, layerId) {
        const remainingLayers = layers[mapId].filter((layer) => layer.id !== layerId);
        const layersToBeRemoved = layers[mapId].filter((layer) => layer.id === layerId);
        layers[mapId] = remainingLayers;

        layersToBeRemoved.forEach(m => m.removeFrom(maps[mapId]));
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
    fitBounds: function (mapId, bounds, options) {
        maps[mapId].fitBounds(L.latLngBounds(bounds.bounds), options);
    },
    fitWorld: function (mapId, options) {
        maps[mapId].fitWorld(options);
    },
    flyTo: function (mapId, latlng, zoom, options) {
        maps[mapId].flyTo(latlng, zoom, options);
    },
    flyToBounds: function (mapId, bounds, options) {
        maps[mapId].flyToBounds(L.latLngBounds(bounds.bounds), options);
    },
    setMaxBounds: function (mapId, bounds) {
        maps[mapId].setMaxBounds(L.latLngBounds(bounds.bounds));
    },
    setMinZoom: function (mapId, zoom) {
        maps[mapId].setMinZoom(zoom)
    },
    setMaxZoom: function (mapId, zoom) {
        maps[mapId].setMaxZoom(zoom)
    },
    panInsideBounds: function (mapId, bounds, options) {
        maps[mapId].panInsideBounds(L.latLngBounds(bounds.bounds), options);
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
    getBounds: function (mapId) {
        return maps[mapId].getBounds();
    },
    getMinZoom: function (mapId) {
        return maps[mapId].getMinZoom();
    },
    getMaxZoom: function (mapId) {
        return maps[mapId].getMaxZoom();
    },
    getBoundsZoom: function (mapId, bounds, inside, point) {
        return maps[mapId].getMaxZoom(L.latLngBounds(bounds.bounds), inside, point);
    }
};

window.leafletLayer = {    
    remove: function (layerId, mapId) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            layer.remove();
        }
    },
    getAttribution: function (layerId, mapId) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            return layer.getAttribution();
        }
    }
}

window.leafletGridLayer = {
    bringToBack: function (layerId, mapId) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            layer.bringToBack();
        }
    },
    bringToFront: function (layerId, mapId) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            layer.bringToFront();
        }
    },
    setOpacity: function (layerId, mapId, op) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            layer.setOpacity(op);
        }
    },
    setZIndex: function (layerId, mapId, zIndex) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            layer.setZIndex(zIndex);
        }
    },
    isLoading: function (layerId, mapId) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            return layer.isLoading();
        }
    },
    redraw: function (layerId, mapId) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            layer.redraw();
        }
    },
    getTileSize: function (layerId, mapId) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            return layer.getTileSize();
        }
    },
}

window.leafletTileLayer = {
    create: function (mapId, tileLayer, objectReference) {
        const layer = L.tileLayer(tileLayer.options.urlTemplate, {
            attribution: tileLayer.options.attribution,
            pane: tileLayer.options.pane,
            tileSize: tileLayer.options.tileSize ? L.point(tileLayer.options.tileSize.width, tileLayer.options.tileSize.height) : undefined,
            opacity: tileLayer.options.opacity,
            updateWhenZooming: tileLayer.options.updateWhenZooming,
            updateInterval: tileLayer.options.updateInterval,
            zIndex: tileLayer.options.zIndex,
            bounds: tileLayer.options.bounds ? L.latLngBounds(tileLayer.options.bounds.bounds) : undefined,
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
    setUrl: function (layerId, mapId, url, noRedraw) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            layer.setUrl(url);
        }
    }
}

window.leafletWmsLayer = {
    create: function (mapId, wmsLayer, objectReference) {
        const layer = L.tileLayer.wms(wmsLayer.options.urlTemplate, {
            layers: wmsLayer.options.layers,
            styles: wmsLayer.options.styles,
            format: wmsLayer.options.format,
            transparent: wmsLayer.options.transparent,
            uppercase: wmsLayer.options.uppercase,
            attribution: wmsLayer.options.attribution,
            pane: wmsLayer.options.pane,
            tileSize: wmsLayer.options.tileSize ? L.point(wmsLayer.options.tileSize.width, wmsLayer.options.tileSize.height) : undefined,
            opacity: wmsLayer.options.opacity,
            updateWhenZooming: wmsLayer.options.updateWhenZooming,
            updateInterval: wmsLayer.options.updateInterval,
            zIndex: wmsLayer.options.zIndex,
            bounds: wmsLayer.options.bounds ? L.latLngBounds(wmsLayer.options.bounds.bounds) : undefined,
            minZoom: wmsLayer.options.minimumZoom,
            maxZoom: wmsLayer.options.maximumZoom,
            subdomains: wmsLayer.options.subdomains,
            errorTileUrl: wmsLayer.options.errorTileUrl,
            zoomOffset: wmsLayer.options.zoomOffset,
            zoomReverse: wmsLayer.options.isZoomReversed,
            detectRetina: wmsLayer.options.detectRetina,
        });
        connectTileLayerEvents(layer, objectReference);
        addLayer(mapId, layer, wmsLayer.id);
    },
}

window.leafletImageOverlayLayer = {
    create: function (mapId, image, objectReference) {
        const layerOptions = {
            pane: image.options.pane,
            attribution: image.options.attribution,
            bubblingMouseEvents: image.options.bubblingMouseEvents,
            opacity: image.options.opacity,
            alt: image.options.alt,
            interactive: image.options.interactive,
            crossOrigin: image.options.crossOrigin,
            errorOverlayUrl: image.options.errorOverlayUrl,
            zIndex: image.options.zIndex,
            className: image.options.className
        };
        const bounds = L.latLngBounds(image.options.bounds.bounds);

        const imgLayer = L.imageOverlay(image.options.url, bounds, layerOptions);
        connectImageOverlayLayerEvents(imgLayer, objectReference);
        addLayer(mapId, imgLayer);
    },
    setOpacity: function (layerId, mapId, op) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            layer.setOpacity(op);
        }
    },
    bringToBack: function (layerId, mapId) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            layer.bringToBack();
        }
    },
    bringToFront: function (layerId, mapId) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            layer.bringToFront();
        }
    },
    setUrl: function (layerId, mapId, url) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            layer.setUrl(url);
        }
    },
    setBounds: function (layerId, mapId, bounds) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            layer.setBounds(L.latLngBounds(bounds.bounds));
        }
    },
    setZIndex: function (layerId, mapId, zIndex) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            layer.setZIndex(zIndex);
        }
    },
    getBounds: function (layerId, mapId) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            return layer.getBounds();
        }
    }
}

window.leafletVideoOverlayLayer = {
    create: function (mapId, video, objectReference) {
        const layerOptions = {
            autoplay: video.options.autoplay,
            loop: video.options.loop,
            keepAspectRatio: video.options.keepAspectRatio,
            muted: video.options.muted,
            pane: video.options.pane,
            attribution: video.options.attribution,
            bubblingMouseEvents: video.options.bubblingMouseEvents,
            opacity: video.options.opacity,
            alt: video.options.alt,
            interactive: video.options.interactive,
            crossOrigin: video.options.crossOrigin,
            errorOverlayUrl: video.options.errorOverlayUrl,
            zIndex: video.options.zIndex,
            className: video.options.className
        };
        const bounds = L.latLngBounds(video.options.bounds.bounds);

        const vidLayer = L.videoOverlay(video.options.url, bounds, layerOptions);
        connectImageOverlayLayerEvents(vidLayer, objectReference);
        addLayer(mapId, vidLayer);
    },
    setOpacity: function (layerId, mapId, op) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            layer.setOpacity(op);
        }
    },
    bringToBack: function (layerId, mapId) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            layer.bringToBack();
        }
    },
    bringToFront: function (layerId, mapId) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            layer.bringToFront();
        }
    },
    setUrl: function (layerId, mapId, url) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            layer.setUrl(url);
        }
    },
    setBounds: function (layerId, mapId, bounds) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            layer.setBounds(L.latLngBounds(bounds.bounds));
        }
    },
    setZIndex: function (layerId, mapId, zIndex) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            layer.setZIndex(zIndex);
        }
    },
    getBounds: function (layerId, mapId) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            return layer.getBounds();
        }
    }
}

window.leafletMarkerLayer = {
    create: function (mapId, marker, objectReference) {
        const layerOptions = {
            icon = marker.options.icon ? createLeafletIcon(marker.options.icon) : undefined,
            keyboard: marker.options.keyboard,
            title: marker.options.title,
            alt: marker.options.alt,
            zIndexOffset: marker.options.zIndexOffset,
            opacity: marker.options.opacity,
            riseOnHover: marker.options.riseOnHover,
            riseOffset: marker.options.riseOffset,
            pane: marker.options.pane,
            shadowPane: marker.options.shadowPane,
            bubblingMouseEvents: marker.options.bubblingMouseEvents,
            draggable: marker.options.draggable,
            autoPan: marker.options.autoPan,
            autoPanPadding: marker.options.autoPanPadding,
            autoPanSpeed: marker.options.autoPanSpeed,
            interactive: marker.options.interactive,
            attribution: marker.options.attribution
        };

        let markerLayer = L.marker(marker.options.latLng, layerOptions);
        connectMarkerEvents(markerLayer, objectReference);
        addLayer(mapId, markerLayer);
    },
    getLatLng: function (layerId, mapId) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            return layer.getLatLng();
        }
    },
    setLatLng: function (layerId, mapId, latlng) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            layer.setLatLng(latlng);
        }
    },
    setZIndexOffset: function (layerId, mapId, offset) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            layer.setZIndexOffset(offset);
        }
    },
    getIcon: function (layerId, mapId) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            return layer.getIcon();
        }
    },
    setIcon: function (layerId, mapId, newIcon) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            layer.setIcon(createLeafletIcon(newIcon));
        }
    },
    setOpacity: function (layerId, mapId, op) {
        let chLayer = layers[mapId].filter((layer) => layer.id === layerId);
        if (chLayer.length > 0) {
            let layer = chLayer[0];
            layer.setOpacity(op);
        }
    },
}

function createLeafletIcon(icon) {
    return L.icon({
        iconUrl: icon.options.iconUrl,
        iconRetinaUrl: icon.options.iconRetinaUrl,
        iconSize: icon.options.iconSize,
        iconAnchor: icon.options.iconAnchor,
        popupAnchor: icon.options.popupAnchor,
        toolipAnchor: icon.options.toolipAnchor,
        shadowUrl: icon.options.shadowUrl,
        shadowRetinaUrl: icon.options.shadowRetinaUrl,
        shadowSize: icon.options.shadowSize,
        shadowAnchor: icon.options.shadowAnchor,
        className: icon.options.className
    });
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

function connectImageOverlayLayerEvents(layer, objectReference) {

    mapEvents(layer, objectReference, {
        "add": "NotifyAdd",
        "remove": "NotifyRemove",
        "load": "NotifyLoad",
        "error": "NotifyError",
        "click": "NotifyClick",
        "dblclick": "NotifyDblClick",
        "mousedown": "NotifyMouseDown",
        "mouseup": "NotifyMouseUp",
        "mouseover": "NotifyMouseOver",
        "mouseout": "NotifyMouseOut",
        "mousemove": "NotifyMouseMove",
        "contextmenu": "NotifyContextMenu",
        "add": "NotifyAdd",
        "remove": "NotifyRemove",
    });
}

function connectMarkerEvents(marker, objectReference) {

    mapEvents(marker, objectReference, {
        "move": "NotifyMove",
        "dragstart": "NotifyDragStart",
        "movestart": "NotifyMoveStart",
        "drag": "NotifyDrag",
        "dragend": "NotifyDragEnd",
        "moveend": "NotifyMoveEnd",
        "click": "NotifyClick",
        "dblclick": "NotifyDblClick",
        "mousedown": "NotifyMouseDown",
        "mouseup": "NotifyMouseUp",
        "mouseover": "NotifyMouseOver",
        "mouseout": "NotifyMouseOut",
        "mousemove": "NotifyMouseMove",
        "contextmenu": "NotifyContextMenu",
        "add": "NotifyAdd",
        "remove": "NotifyRemove",
    });
}

function addLayer(mapId, layer, layerId) {
    layer.id = layerId;
    layers[mapId].push(layer);
    layer.addTo(maps[mapId]);
}