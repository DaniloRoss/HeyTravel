const urlParams = new URLSearchParams(window.location.search); 

mapboxgl.accessToken = 'pk.eyJ1IjoiZGFueXJlZHMiLCJhIjoiY2t6bjEyamNxMDN6NzJucXVnZjZ2enM3eCJ9.ieT8jUJor2Z0q69as5-WYQ';
var map = new mapboxgl.Map({
    container: 'map',
    style: 'mapbox://styles/danyreds/ckzmpnpey001h15oatavzcetr',
    center: [urlParams.get('Longitude'), urlParams.get('Latitude')],
    zoom: 4
});

map.on('load', function () {

    map.addSource('COVID', {
        type: 'geojson',
        data: '../json/mappa_new.json'
    });

    map.addLayer({
        id: 'covidcases',
        type: 'fill',
        source: 'COVID',
        'paint': {
            'fill-color': "#AA1100",
            'fill-opacity': {
                property: 'casi',
                stops: [
                    [0, 0],
                    [10000, 0.15],
                    [1000000, 0.5],
                    [2000000, 0.7],
                    [100000000, 0.8],
                ]
            }
        }
    });
});

map.on('click', 'covidcases', function (e) {
    var HTML = '<b>' + e.features[0].properties.name + '</b>' + ' ' + e.features[0].properties.casi + ' cases';
    new mapboxgl.Popup()
        .setLngLat(e.lngLat)
        .setHTML(HTML)
        .addTo(map);
});

// Change the cursor to a pointer when the mouse is over the states layer.
map.on('mouseenter', 'covidcases', function () {
    map.getCanvas().style.cursor = 'pointer';
});

// Change it back to a pointer when it leaves.
map.on('mouseleave', 'covidcases', function () {
    map.getCanvas().style.cursor = '';
});