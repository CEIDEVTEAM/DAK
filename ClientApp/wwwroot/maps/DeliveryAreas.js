window.onload = initMap;

var map;
var markers = [];


//funcion iniciadora del mapa
function initMap() {

    var currentPoly = [];
    const centro = { lat: 39.866667, lng: -4.033333 };
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 14,
        center: centro,
        mapTypeId: "roadmap",
    });
    // This event listener will call addMarker() when the map is clicked.
    map.addListener("click", (event) => {
        addMarker(event.latLng);
    });

    document.getElementById("btn2").addEventListener("click", function () {
        createPoly(markers)
    });
    document.getElementById("btn2").addEventListener("click", function () {
        distance(map)
    });

    handleResponse();
}

//pequeñas funcionalidades auxiliares
function addMarker(location) {
    const marker = new google.maps.Marker({
        position: location,
        map: map,
    });
    markers.push(marker);
}

function setMapOnAll(map) {
    for (let i = 0; i < markers.length; i++) {
        markers[i].setMap(map);
    }
}

function clearMarkers() {
    setMapOnAll(null);
}

function showMarkers() {
    setMapOnAll(map);
}

function deleteMarkers() {
    clearMarkers();
    markers = [];
}

function removeLine(name) {

    name.setMap(null);
}

function showArrays(event) {

    const polygon = this;
    const vertices = polygon.getPath();
    const nombre = polygon.name;
    const recAct = polygon.count;
    let contentString =
        "<b>Zona: " + nombre + "</b><br>" +
        "<b>Reclamos activos actuales: " + recAct + "</b><br>"

    infoWindow.setContent(contentString);
    infoWindow.setPosition(event.latLng);
    infoWindow.open(map);
}

//guardar zona
function getZona(polygon) {
    var poligono = polygon;
    var vertices = poligono.getPath();
    var valTxtNombre = document.getElementById("Name").value;
    var valTxtColor = document.getElementById("Color").value;
    var colCords = [];


    for (let i = 0; i < vertices.getLength(); i++) {
        const xy = vertices.getAt(i);
        let lat = xy.lat();
        let long = xy.lng();
        let hash = i;

        colCords.push({ Latitude: lat, Longitude: long, OrderNumber: hash })

    }
    var json = { name: valTxtNombre, color: valTxtColor, ColVexels: colCords }
    $.ajax({
        type: 'POST',
        data: json,
        url: 'AddDeliveryArea',
        success: function (respuesta) {

        },
        error: function (respuesta) {

        }
    })


}
function createPoly(coordinates) {

    var coords = [];
    for (let i = 0; i < coordinates.length; i++) {

        let latitude = parseFloat(coordinates[i].getPosition().lat().toFixed(6));
        let long = parseFloat(coordinates[i].getPosition().lng().toFixed(6));
        let singleCoord = { lat: latitude, lng: long };
        coords.push(singleCoord);

    }

    var color = document.getElementById("Color").value;
    //var name = document.getElementById("zoneColor").value;

    const polyCoords = coords;
    // Construct the polygon.
    const polygon = new google.maps.Polygon({
        paths: polyCoords,
        strokeColor: color,
        strokeOpacity: 0.8,
        strokeWeight: 3,
        fillColor: color,
        fillOpacity: 0.90,
        editable: true

    });
    polygon.setMap(map);

    deleteMarkers();


    polygon.addListener("click", showArrays);
    infoWindow = new google.maps.InfoWindow();

    document.getElementById("btn1").addEventListener("click", function () {
        getZona(polygon)
    });
    

    return polygon;
}
//graficar zonas
function handleResponse() {

    $.ajax({
        type: 'GET',

        url: 'PopulatePolygons',
        success: function (response) {
            for (let i = 0; i < response.length; i++) {

                zonesPopulate(response[i]);
                console.log(response[i]);
            }

        },
        error: function (response) {

        }
    })

}

function zonesPopulate(item) {

    var coords = [];
    var orderVerts = item.colVexels.sort((a, b) => {
        return a.ordenNumber - b.ordenNumber;
    });

    for (let i = 0; i < orderVerts.length; i++) {

        let longitude = parseFloat(item.colVexels[i].longitude);
        let latitude = parseFloat(item.colVexels[i].latitude);
        let singleCoord = { lat: latitude, lng: longitude };
        coords.push(singleCoord);

    }

    var color = item.color;
    var nombre = item.name;
    var rActivos = item.reclamosActivos;

    const polyCoords = coords;
    // Construct the polygon.
    const polygon = new google.maps.Polygon({

        name: nombre,
        count: rActivos,
        paths: polyCoords,
        strokeColor: color,
        strokeOpacity: 0.5,
        strokeWeight: 3,
        fillColor: color,
        fillOpacity: 0.2,


    });
    polygon.setMap(map);


    polygon.addListener("click", showArrays);
    infoWindow = new google.maps.InfoWindow();

}





function distance(map) {
    // initialize services
    const geocoder = new google.maps.Geocoder();
    const service = new google.maps.DistanceMatrixService();
    // build request
    const origin1 = { lat: 55.93, lng: -3.118 };
    const origin2 = "Greenwich, England";
    const destinationA = "Stockholm, Sweden";
    const destinationB = { lat: 50.087, lng: 14.421 };
    const request = {
        origins: [origin1, origin2],
        destinations: [destinationA, destinationB],
        travelMode: google.maps.TravelMode.DRIVING,
        unitSystem: google.maps.UnitSystem.METRIC,
        avoidHighways: false,
        avoidTolls: false,
    };

    // put request on page
    document.getElementById("request").innerText = JSON.stringify(
        request,
        null,
        2
    );
    // get distance matrix response
    service.getDistanceMatrix(request).then((response) => {
        // put response
        document.getElementById("request").innerText = JSON.stringify(
            response,
            null,
            2
        );

        // show on map
        const originList = response.originAddresses;
        const destinationList = response.destinationAddresses;

        deleteMarkers(markersArray);

        const showGeocodedAddressOnMap = (asDestination) => {
            const handler = ({ results }) => {
                map.fitBounds(bounds.extend(results[0].geometry.location));
                markersArray.push(
                    new google.maps.Marker({
                        map,
                        position: results[0].geometry.location,
                        label: asDestination ? "D" : "O",
                    })
                );
            };
            return handler;
        };

        for (let i = 0; i < originList.length; i++) {
            const results = response.rows[i].elements;

            geocoder
                .geocode({ address: originList[i] })
                .then(showGeocodedAddressOnMap(false));

            for (let j = 0; j < results.length; j++) {
                geocoder
                    .geocode({ address: destinationList[j] })
                    .then(showGeocodedAddressOnMap(true));
            }
        }
    });


}